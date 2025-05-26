import grpc
from google.protobuf.timestamp_pb2 import Timestamp
import trainerPython_pb2
import asyncio
import trainerPython_pb2_grpc
from repositories.trainer_repository import TrainerRepository
from mappers.trainer_mappers import domain_to_response, request_to_domain

class TrainerServiceServicer(trainerPython_pb2_grpc.TrainerServiceServicer):
    def __init__(self, repository: TrainerRepository):
        self._repo = repository

    async def GetTrainer(self, request, context):
        trainer = await self._repo.get_by_id(request.id)
        if trainer is None:
            context.set_code(grpc.StatusCode.NOT_FOUND)
            context.set_details(f"Trainer {request.id} not found")
            return trainerPython_pb2.TrainerResponse()
        return domain_to_response(trainer)

    async def CreateTrainer(self, request_iterator, context):
        created_responses = []
        async for req in request_iterator:
            domain_trainer = request_to_domain(req)
            existing = await self._repo.get_by_name(domain_trainer.name)
            if existing:
                continue
            new_trainer = await self._repo.create(domain_trainer)
            created_responses.append(domain_to_response(new_trainer))

        return trainerPython_pb2.CreateTrainersResponse(
            success_count=len(created_responses),
            trainers=created_responses
        )
        
    async def GetTrainersByName(self, request, context):
        if not request.name or len(request.name) <= 1:
            context.abort(
                grpc.StatusCode.INVALID_ARGUMENT,
                "Name field is required"
            )
        
        trainers = await self._repo.get_by_name(request.name)
        
        for trainer in trainers: 
            await asyncio.sleep(5)
            yield domain_to_response(trainer)
            

