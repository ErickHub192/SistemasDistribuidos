from dataclasses import dataclass, field
from datetime import datetime
from typing import Optional, List

@dataclass
class Medal:
    region: str
    type: int

@dataclass
class Trainer:
    id: Optional[str] = None
    name: Optional[str] = None
    age: int = 0
    birthday: datetime = field(default_factory=datetime.utcnow)
    medals: List[Medal] = field(default_factory=list)
    created_at: datetime = field(default_factory=datetime.utcnow)
