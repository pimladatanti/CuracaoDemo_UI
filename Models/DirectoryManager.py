# Directory manager file is the connection between front & backend
import sys
sys.path.append("/Applications/IronPython.2.7.12/Lib")
import os
sys.path.append(os.path.abspath("Models"))
#sys.path.append("/Library/Frameworks/Python.framework")

import wave
from WavManager import WavManager

# TODO: add checkIfEncrypted, checkIfDecrypted
# DirectoryManager is the main interface between front & backend
class DirectoryManager:

    # Initialize a manager with an input and output
    def __init__(self):
        pass
        #wavManager = WavManager()
 #, input_directory):
        #fileMonitor = FileMonitorDaemon()
        #self.input_directory = input_directory
        #self.prepare_directories()

    # creates dirs for decrypted, encrypted, logs, + files for inputLog, outputLog
    def prepare_directories(self):
        print("Preparing i/o directories")

        # Create paths for Log file
        logs_path = os.path.join(self.input_directory, "Logs")

        # Create folders if they don't already exist
        if not os.path.isdir(logs_path):
            print("\t\"Logs\" directory successfully created.")
            os.mkdir(logs_path)

    def encrypt(self): #, file_to_encrypt):
        
        return "Encrypted" #, file_to_encrypt)
        
        # check file status - if encrypted, do nothing
        # if decrypted, encrypt
        #sample_wav_manager = WavManager()
        #sample_wav_manager.encrypt("/Users/pimladatanti/Projects/curacaoWebAppTest/curacaoWebAppTest/Models/crickets.wav")#file_to_encrypt)

    def decrypt(self): #, file_to_decrypt):
        return "Decrypted"
        #print("Decrypting recording:", file_to_decrypt)
        # check file status - if decrypted, do nothing
        # if encrypted, decrypt
        # sample_wav_manager = WavManager()
        #sample_wav_manager.encrypt(file_to_decrypt)

    def play_file(self): #, file_to_play):
        #print("Playing recording:", file_to_play)
        # check file status -- if decrypted, play decrypted file
        # @Zack, should we encapsulate this wavPlayer in wavManager (add play method to wavManager)
        # instead of having a separate class?
        #sampleP = WavPlayer(file_to_play)
        #sample_wav_manager = WavManager()
        return "Lilly"
        #sample_wav_manager.play_wav("/Users/pimladatanti/Projects/curacaoWebAppTest/curacaoWebAppTest/Models/crickets.wav")

    # delete a desired file
    #def delete_file(self, file_to_delete):
        #print("Deleting recording:", file_to_delete)
        # delete file from outputDir/Decrypted
        #os.remove(file_to_delete)


    #sample_manager = DirectoryManager("osTools/sampleInputDir")
    #sample_manager.play_file("osTools/sampleInputDir/crickets.wav")


