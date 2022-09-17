import socket

# 접속할 서버 주소 localhost = 127.0.0.1
HOST = '127.0.0.1' 

# 클라이언트 접속을 대기하는 포트 번호 
PORT = 8000       

# 소켓 객체를 생성 (주소 체계 : IPv4,소켓 타입 : TCP)
server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

# 포트 사용중 예외 처리 
server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)

# 소켓을 특정 네트워크 인터페이스와 포트 번호에 연결 
# 서버 주소와 포트 번호을 인자로 가짐 
server_socket.bind((HOST, PORT))

# 서버가 클라이언트의 접속을 허용 
server_socket.listen()

# 대기하면서 클라이언트가 접속하면 새로운 소켓을 리턴 
client_socket, addr = server_socket.accept()

# 접속한 클라이언트 주소 
print('Connected by', addr)

# 무한 루프 
while True:

    # 클리이언트가 송신한 메시지를 수신하기 위해서 대기 
    data = client_socket.recv(1024)

    # 빈 문자열을 수신하면 루프를 중지 
    if not data:
        break

    # 수신 받은 메시지를 출력 
    print('수신 메시지:',addr,data.decode())
