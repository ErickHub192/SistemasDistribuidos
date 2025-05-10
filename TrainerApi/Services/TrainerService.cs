using Grpc.Core;
using Google.Protobuf.WellKnownTypes;
namespace TrainerApi.Services;

public class TrainerService : TrainerApi.TrainerService.TrainerServiceBase{
    public override async Task<TrainerResponse> GetTrainer(TrainerByIdRequest request, ServerCallContext context)
    {
        return new TrainerResponse{
            Id = Guid.NewGuid().ToString(),
            Name = "Pascual",
            Age = 99,
            Birthday = Timestamp.FromDateTime(DateTime.UtcNow),
            CreatedAt = Timestamp.FromDateTime(DateTime.UtcNow),
            Medals    = {
            new Medals{ Region = "MX", Type =MedalType.Gold },
            new Medals{ Region = "MX", Type =MedalType.Silver }, 
            new Medals{ Region = "MX", Type =MedalType.Bronze },
        }
    };
}
}