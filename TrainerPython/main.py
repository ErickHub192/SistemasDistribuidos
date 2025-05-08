# main.py

from concurrent import futures
import grpc
import trainer_pb2_grpc
from services.Trainservicepy import TrainerServiceServicer

def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    trainer_pb2_grpc.add_TrainerServiceServicer_to_server(
        TrainerServiceServicer(), server
    )
    server.add_insecure_port('[::]:50051')
    server.start()
    print("Server started on port 50051")
    server.wait_for_termination()

if __name__ == '__main__':
    try:
        serve()
    except Exception as e:
        import traceback
        print("¡Error al arrancar el servidor!", e)
        traceback.print_exc()
        raise
