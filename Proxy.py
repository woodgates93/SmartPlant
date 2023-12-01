import requests 
from socket import *
import threading


RECEVING_PORT = 6666
BUFFER_SIZE = 1024
REST_URL = 'http://localhost:5053/api/Temp'

server = socket(AF_INET, SOCK_DGRAM)
server.bind(('', RECEVING_PORT))

def do_client():
        data, client_addr = server.recvfrom(BUFFER_SIZE)
        t = data.decode()
        print(t)

        headers = {'Content-type': 'application/json'}
        r = requests.post(REST_URL, data=t, headers=headers)
        
        print(r)

while True:
        thread = threading.Thread(target = do_client())
        thread.start()