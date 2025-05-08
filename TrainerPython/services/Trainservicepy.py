# services/Trainservice.py

from datetime import datetime
from google.protobuf.timestamp_pb2 import Timestamp
import trainer_pb2
import trainer_pb2_grpc

class TrainerServiceServicer(trainer_pb2_grpc.TrainerServiceServicer):
    def GetTrainer(self, request, context):
        # Creamos los timestamps hardcodeados
        birthday = Timestamp()
        birthday.FromDatetime(datetime.utcnow())
        created_at = Timestamp()
        created_at.FromDatetime(datetime.utcnow())

        # Construcción de la respuesta (usando trainer_pb2, no trainer__pb2)
        return trainer_pb2.TrainerResponse(
            id="123e4567-e89b-12d3-a456-426655440000",
            Name="Pascualito",
            Age=25,
            Birthday=birthday,
            Created_at=created_at,          # coincida con el nombre en el .proto
            medals=[
                trainer_pb2.Medals(Region="North America", Type=trainer_pb2.GOLD),
                trainer_pb2.Medals(Region="South America", Type=trainer_pb2.SILVER),
            ]
        )
