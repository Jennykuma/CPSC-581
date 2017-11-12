#!/usr/bin/env python

# Jenny Le
# CPSC 581 - P1
# Help from:
# https://learn.adafruit.com/neopixels-on-raspberry-pi/software
# https://learn.adafruit.com/raspberry-pi-e-mail-notifier-using-leds/python-script

from imapclient import IMAPClient # import IMAPClient
from neopixel import *
import RPi.GPIO as GPIO
import time
import picamera
import os
import threading

GPIO.setwarnings(False)
GPIO.setmode(GPIO.BOARD)
GPIO.setup(11, GPIO.IN, pull_up_down=GPIO.PUD_UP) # apparently works for button 2
GPIO.setup(13, GPIO.IN, pull_up_down=GPIO.PUD_UP) # apparently works for button 1
GPIO.setup(15, GPIO.IN, pull_up_down=GPIO.PUD_UP) # apparently works for button 4
GPIO.setup(16, GPIO.IN, pull_up_down=GPIO.PUD_UP) # apparently works for button 3

# LED strip configuration:
LED_COUNT      = 2      # Number of LED pixels.
LED_PIN        = 18      # GPIO pin connected to the pixels (18 UserWarnings PWM!).
LED_FREQ_HZ    = 800000  # LED signal frequency in hertz (usually 800khz)
LED_DMA        = 5       # DMA channel to use for generating signal (try 5)
LED_BRIGHTNESS = 10     # Set to 0 for darkest and 255 for brightest
LED_INVERT     = False   # True to invert the signal (when using NPN transistor level shift)
LED_CHANNEL    = 0       # set to '1' for GPIOs 13, 19, 41, 45 or 53
LED_STRIP      = ws.WS2811_STRIP_GRB   # Strip type and colour ordering

camera = picamera.PiCamera() # create camera object

DEBUG = True # Boolean 
HOSTNAME = 'imap.gmail.com'
USER = 'GMAIL GOES HERE' # I AM NOT PUTTING MY EMAIL HERE!! Put your own!! It has to be gmail
PASSWORD = 'GMAIL PW GOES HERE' # SAME GOES FOR HERE!!
MAILBOX = 'Inbox' # Inbox to check
NEWMAIL_OFFSET = 1 # New mail is 1
MAIL_CHECK_FREQ = 2 # check at a frequency of 2

# Code from https://learn.adafruit.com/neopixels-on-raspberry-pi/software
def wheel(pos):
	"""Generate rainbow colors across 0-255 positions."""
	if pos < 85:
		return Color(pos * 3, 255 - pos * 3, 0)
	elif pos < 170:
		pos -= 85
		return Color(255 - pos * 3, 0, pos * 3)
	else:
		pos -= 170
		return Color(0, pos * 3, 255 - pos * 3)

# Code from https://learn.adafruit.com/neopixels-on-raspberry-pi/software 
def colorWipe(strip, color, wait_ms=20):
	"""Wipe color across display a pixel at a time."""
	for i in range(strip.numPixels()):
		strip.setPixelColor(i, color)
		strip.show()
		time.sleep(wait_ms/1000.0)

# Code from https://learn.adafruit.com/neopixels-on-raspberry-pi/software
def rainbowCycle(strip, wait_ms=20, iterations=1):
	"""Draw rainbow that uniformly distributes itself across all pixels."""
	for j in range(256*iterations):
		for i in range(strip.numPixels()):
			strip.setPixelColor(i, wheel((int(i * 256 / strip.numPixels()) + j) & 255))
		strip.show()
		time.sleep(wait_ms/1000.0)

# Got help from the code https://learn.adafruit.com/raspberry-pi-e-mail-notifier-using-leds/python-script
def loop():
    try:
            
        if GPIO.input(11) == False:
            print("Button 2 pressed") # FILL EMAIL OUT HERE
            os.system('echo "MESSAGE GOES HERE" | ssmtp email@emailAddress.com')
            time.sleep(0.2)
        elif GPIO.input(13) == False:
            print("Button 1 pressed") # FILL EMAIL OUT HERE
            os.system('echo "MESSAGE GOES HERE" | ssmtp email@emailAddress.com')
            time.sleep(0.2)
        elif GPIO.input(15) == False:
            print("Button 4 pressed") # Take a picture
            # CREATE FOLDER in DESKTOP called P1
            # CREATE FOLDER in P1 called images
            camera.capture('/home/pi/Desktop/P1/images/' + time.strftime("%Y-%m-%d_%H-%M-%S") + '.jpg') # take a photo
            time.sleep(0.2)
        elif GPIO.input(16) == False:
            print("Button 3 pressed") # FILL EMAIL OUT HERE
            os.system('echo "MESSAGE GOES HERE" | ssmtp email@emailAddress.com')
            time.sleep(0.2)
    except:
        print("Button waiting")
    
def checkMail():
        while True:
            print("hello")
            server = IMAPClient(HOSTNAME, use_uid=True, ssl=True)
            server.login(USER,PASSWORD) # LOG INTO THE SERVER
            
            if DEBUG:
                print('Logging in as ' + USER)
                select_info = server.select_folder(MAILBOX)
                print('%d messages in INBOX' % select_info['EXISTS'])
                
            folder_status = server.folder_status(MAILBOX, 'UNSEEN')
            newmails = int(folder_status['UNSEEN']) # to newmails if unseen emails exist
            
            if DEBUG:
                print ("You have ", newmails, " new emails!")
                
            while newmails >= NEWMAIL_OFFSET: # Change colours when there are new messages >= 1
                colorWipe(strip, Color(255, 0, 0))  # Red wipe
                time.sleep(0.2)
                colorWipe(strip, Color(0, 255, 0))  # Blue wipe
                time.sleep(0.2)
                colorWipe(strip, Color(0, 0, 255))  # Green wipe
                time.sleep(0.2)
                if DEBUG:
                    print('Logging in as ' + USER)
                    select_info = server.select_folder(MAILBOX)
                    print('%d messages in INBOX' % select_info['EXISTS'])
                        
                    folder_status = server.folder_status(MAILBOX, 'UNSEEN')
                    newmails = int(folder_status['UNSEEN'])
                    if newmails < NEWMAIL_OFFSET:
                        break
            else:
                rainbowCycle(strip) # else just do the rainbow
            server.logout()
            #time.sleep(MAIL_CHECK_FREQ)
    
if __name__ == '__main__':
    strip = Adafruit_NeoPixel(LED_COUNT, LED_PIN, LED_FREQ_HZ, LED_DMA, LED_INVERT, LED_BRIGHTNESS, LED_CHANNEL, LED_STRIP)
    # Intialize the library (must be called once before other functions).
    strip.begin()
    rainbowCycle(strip)
    try:
        print ("Press ctrl-c to quit")
        threading.Thread(target=checkMail).start() # run thread to check mail
        while True:
            loop()    
    finally:
        GPIO.cleanup()

