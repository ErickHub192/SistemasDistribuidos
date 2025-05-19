from typing import List, Optional
from motor.motor_asyncio import AsyncIOMotorCollection
from bson import ObjectId
from infrastructure.documents.trainer_document import TrainerDocument
from infrastructure.documents.medals_document import MedalDocument
from models.trainer import Trainer
from mappers.trainer_mappers import document_to_domain, domain_to_document
from repositories.i_trainer_repository import ITrainerRepository

class TrainerRepository(ITrainerRepository):
    def __init__(self, collection: AsyncIOMotorCollection):
        
        self.collection = collection

    async def get_by_id(self, id: str) -> Optional[Trainer]:
        
        try:
            oid = ObjectId(id)
        except Exception:
            return None

        raw = await self.collection.find_one({"_id": oid})
        if raw is None:
            return None

        
        raw["id"] = str(raw["_id"])
        raw.pop("_id", None)

        
        medals_raw = raw.get("medals", [])
        raw["medals"] = [
            m if isinstance(m, MedalDocument) else MedalDocument(**m)
            for m in medals_raw
        ]

        trainer_doc = TrainerDocument(**raw)
        return document_to_domain(trainer_doc)

    async def create(self, trainer: Trainer) -> Trainer:
        
        trainer_doc = domain_to_document(trainer)
        data = trainer_doc.to_bson()

        result = await self.collection.insert_one(data)
        trainer_doc.id = str(result.inserted_id)

        return document_to_domain(trainer_doc)

    async def get_by_name(self, name: str) -> List[Optional[Trainer]]:
        
        cursor = self.collection.find(
            {"name": {"$regex": name, "$options": "i"}}
        )
        raws = await cursor.to_list(length=None)

        trainers: List[Optional[Trainer]] = []
        for raw in raws:
            raw["id"] = str(raw["_id"])
            raw.pop("_id", None)

            medals_raw = raw.get("medals", [])
            raw["medals"] = [
                m if isinstance(m, MedalDocument) else MedalDocument(**m)
                for m in medals_raw
            ]

            trainer_doc = TrainerDocument(**raw)
            trainers.append(document_to_domain(trainer_doc))

        return trainers

        