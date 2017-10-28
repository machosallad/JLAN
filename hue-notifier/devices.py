
import math
from time import time, sleep
import phue
from hue_helper import ColorHelper
import logging
import threading
import random

class Device(object):
    def __init__(self):
        super(Device, self).__init__()
        self.logger = logging.getLogger(self.__class__.__name__)
        self.current_color = (0,0,0)
        self.lock = threading.Lock()
        self.flashlock = threading.Lock()

    def set_color(self,color):
        raise Exception("Function not implemented , whoops")

    def flash(self,color_1,color_2,ntimes=10,interval=0.2,nonblocking = False):
        if nonblocking:
            t = threading.Thread(target=self.flash,args=(color_1,color_2,ntimes,interval))
            t.start()
            return
        else:
            with self.flashlock:
                old_color = self.current_color
                for x in range (ntimes):
                    self.set_color(color_1)
                    sleep(interval)
                    self.set_color(color_2)
                    sleep(interval)
                self.set_color(old_color)

    def start(self):
        raise Exception("Function not implemented, whoops")

    def stop(self):
        raise Exception("Function not implemented, whoops")


class Hue(Device):
    def __init__(self,ip):
        super(Hue, self).__init__()
        self.logger = logging.getLogger("Hue")
        phue.logger.setLevel(logging.INFO)
        self.bridge = phue.Bridge(ip=ip,config_file_path='.hue_config')
        self.current_phue_status = {}
        self.chelper = ColorHelper()
        self.current_color = self._XYtoRGB(self.bridge.lights[0].xy[0],self.bridge.lights[0].xy[1],self.bridge.lights[0].brightness)

    def flash(self,color_1,color_2,ntimes=2,interval=0.2,nonblocking = False):
        if nonblocking:
            t = threading.Thread(target=self.flash,args=(color_1,color_2,ntimes,interval))
            t.start()
            return
        else:
            with self.flashlock:
                #store the old states
                old_colors = {}
                for l in self.bridge.lights:
                    if(l.type == "Extended color light"):
                        old_colors[l] = (l.xy, l.brightness)
                    else:
                        print("Got non RGB light from bridge!")
                try:
                    #flash a bunch
                    for x in range (ntimes):

                        for l in self.bridge.lights:
                            if(l.type == "Extended color light"):
                                l.brightness = 254
                                l.transitiontime = 0
                                l.xy = self._RGBtoXY(color_1[0],color_1[1],color_1[2])
                        sleep(interval)

                        for l in self.bridge.lights:
                            if(l.type == "Extended color light"):
                                l.brightness = 254
                                l.transitiontime = 0
                                l.xy = self._RGBtoXY(color_2[0],color_2[1],color_2[2])
                        sleep(interval)
                finally:
                    #reset to old states
                    sleep(0.3)
                    for l in self.bridge.lights:
                        if(l.type == "Extended color light"):
                            while l.xy != old_colors[l][0]:
                                l.transitiontime = 0
                                l.brightness = old_colors[l][1]
                                l.xy = old_colors[l][0]


    def start(self):
        pass

    def stop(self):
        pass

    def set_color(self,rgb=None,xy=None,brightness=None):
        with self.lock:
            self.bridge.set_light(self.rgb_ids,{'bri':254, 'transitiontime': 0, 'xy':xy, 'on':True})

    def _enhancecolor(self,normalized):
        if normalized > 0.04045:
            return math.pow( (normalized + 0.055) / (1.0 + 0.055), 2.4)
        else:
            return normalized / 12.92

    def _XYtoRGB(self,x,y,brightness):
        return self.chelper.getRGBFromXYAndBrightness(x, y, brightness)

    def _RGBtoXY(self,r, g, b):
        return self.chelper.getXYPointFromRGB(r, g, b)
