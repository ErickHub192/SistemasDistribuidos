from datetime import datetime
from typing import List, Optional
from google.protobuf.timestamp_pb2 import Timestamp
import trainerPython_pb2 as pb
from models.trainer import Trainer, Medal
from infrastructure.documents import TrainerDocument, MedalDocument
import trainerPython_pb2_grpc
def _to_timestamp(dt: datetime) -> Timestamp:
    ts = Timestamp()
    ts.FromDatetime(dt)
    return ts

def _from_timestamp(ts: Timestamp) -> datetime:
    return ts.ToDatetime()

def request_to_domain(req: pb.CreateTrainerRequest) -> Trainer:
    return Trainer(
        id=None,
        name=req.name,
        age=req.age,
        birthday=_from_timestamp(req.birthdate),
        created_at=datetime.utcnow(),
        medals=[Medal(region=m.region, type=m.type) for m in req.medals],
    )

def document_to_domain(doc: Optional[TrainerDocument]) -> Optional[Trainer]:
    if doc is None:
        return None
    return Trainer(
        id=doc.id,
        name=doc.name,
        age=doc.age,
        birthday=doc.birthday,
        medals=[Medal(region=m.region, type=m.type) for m in doc.medals],
        created_at=doc.created_at,
    )

def domain_to_document(tr: Trainer) -> TrainerDocument:
    return TrainerDocument(
        id=tr.id,
        name=tr.name,
        age=tr.age,
        birthday=tr.birthday,
        created_at=tr.created_at,
        medals=[MedalDocument(region=m.region, type=m.type) for m in tr.medals]
    )

def domain_to_response(tr: Trainer) -> pb.TrainerResponse:
    return pb.TrainerResponse(
        id=tr.id or "",
        name=tr.name or "",
        age=tr.age,
        birthdate=_to_timestamp(tr.birthday),
        created_at=_to_timestamp(tr.created_at),
        medals=[pb.Medals(region=m.region, type=m.type) for m in tr.medals],
    )

def create_trainers_response_to_domains(
    rpc: pb.CreateTrainersResponse,
) -> List[Trainer]:    
    result: List[Trainer] = []
    for rpc_tr in rpc.trainers:
        tr = Trainer(
            id=rpc_tr.id,
            name=rpc_tr.name,
            age=rpc_tr.age,
            birthday=_from_timestamp(rpc_tr.birthdate),
            medals=[Medal(region=m.region, type=m.type) for m in rpc_tr.medals],
            created_at=_from_timestamp(rpc_tr.created_at),
        )
        result.append(tr)
    return result
