import requests 
from socket import *
import threading
import json

RECEIVING_PORT = 6666
BUFFER_SIZE = 1024
REST_URL = 'http://localhost:5053/api/Temp'

data_1 = {}
data_2 = {}
sensor_data = {}

server = socket(AF_INET, SOCK_DGRAM)
server.bind(('', RECEIVING_PORT))

def do_client():
        global data_1, data_2, sensor_data 
        data, addr = server.recvfrom(BUFFER_SIZE)

        temp_data = json.loads(data.decode())
        if temp_data['id'] % 2 != 0:
                data_1 = temp_data
                print('data1:')
                print(data_1)
        else:
                data_2 = temp_data 
                print('data2:')
                print(data_2)

        if bool(data_1) and bool(data_2):
                sensor_data.update(data_1)
                sensor_data.update(data_2)     
                print('sensor_data:')
                print(sensor_data)           
                try:
                        headers = {'Content-type': 'application/json'}
                        r = requests.post(REST_URL, data=json.dumps(sensor_data), headers=headers)
                        data_1.clear()
                        data_2.clear()
                        sensor_data.clear()

                except Exception as e:
                        print(f"Error: {e}")
                        data_1.clear()
                        data_2.clear()
                        sensor_data.clear()

while True:
        thread = threading.Thread(target=do_client)
        thread.start()
