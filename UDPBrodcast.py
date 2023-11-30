from socket import *
#from _sensehat import SenseHat

servername = 'localhost'
serverport = 6666

broadcastsocket = socket (AF_INET, SOCK_DGRAM)

broadcastsocket.setsockopt(SOL_SOCKET, SO_BROADCAST, 1)

tekst = 'hej'.encode('utf-8')
broadcastsocket.sendto(tekst, ('<broadcast>', serverport))



