from dataclasses import dataclass, field
from datetime import datetime
from typing import List, Optional
from infrastructure.documents.medals_document import MedalDocument

@dataclass
class TrainerDocument:
    id: Optional[str] = None
    name: Optional[str] = None
    age: int = 0
    birthday: datetime = field(default_factory=datetime.utcnow)
    created_at: datetime = field(default_factory=datetime.utcnow)
    medals: List[MedalDocument] = field(default_factory=list)

    def to_bson(self) -> dict:
        data = {
            "name": self.name,
            "age": self.age,
            "birthday": self.birthday,
            "created_at": self.created_at,
            "medals": [m.to_bson() for m in self.medals]
        }
        if self.id:
            data["_id"] = self.id
        return data
