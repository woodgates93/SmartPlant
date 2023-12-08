import requests 
from socket import *
import threading
import json

RECEIVING_PORT = 45600
BUFFER_SIZE = 1024
REST_URL = 'http://localhost:5053/api/Temp'

data_1 = {}
data_2 = {}

server = socket(AF_INET, SOCK_DGRAM)
server.bind(('', RECEIVING_PORT))

def do_client():
    global data_1, data_2  # Declare data_1 and data_2 as global variables

    data, addr = server.recvfrom(BUFFER_SIZE)

    temp_data = json.loads(data.decode())
    if temp_data['id'] % 2 != 0:
        data_1 = temp_data
    else:
        data_2 = temp_data 

    if not data_1 and not data_2:
        data_1.update(data_2)
        data_1.clear()
        data_2.clear()
    
    print(data_1)

    try:
        headers = {'Content-type': 'application/json'}
        r = requests.post(REST_URL, data=json.dumps(data_1), headers=headers)
    except Exception as e:
        print(f"Error: {e}")

while True:
    thread = threading.Thread(target=do_client)
    thread.start()
