from dataclasses import dataclass

@dataclass
class MedalDocument:
    region: str
    type: int

    def to_bson(self) -> dict:
        return {
            "region": self.region,
            "type": self.type
        } 