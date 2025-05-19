import os
import asyncio
import grpc
import grpc.aio
from motor.motor_asyncio import AsyncIOMotorClient
import trainerPython_pb2_grpc
from services.trainer_service import TrainerServiceServicer
from repositories.trainer_repository import TrainerRepository
from config import MongoDBSettings

async def serve():
    
    settings = MongoDBSettings.from_env()

    
    client = AsyncIOMotorClient(settings.connection_string)
    db = client[settings.database_name]
    collection = db.get_collection(settings.collection_name)

    
    repo = TrainerRepository(collection)
    service = TrainerServiceServicer(repository=repo)

    
    server = grpc.aio.server()
    trainerPython_pb2_grpc.add_TrainerServiceServicer_to_server(service, server)
    server.add_insecure_port("[::]:50051")
    await server.start()
    print("gRPC aio Server started on port 50051")
    await server.wait_for_termination()

if __name__ == "__main__":
    asyncio.run(serve())


