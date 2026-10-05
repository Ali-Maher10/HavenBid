using Microsoft.AspNetCore.Mvc;
using MiniValidation;

public static class WebApplicationBidExtension
{
    public static void MapBidEndpoints(this WebApplication app)
    {
    app.MapGet("/house/{houseId:int}/bids", async(IBidRepository repo,IHouseRepository houseRepo, int houseId) => {
    if (await houseRepo.Get(houseId) == null)
        return Results.Problem($"House with ID {houseId} not found.", statusCode: 404);
    var bids = await repo.Get(houseId);
    return Results.Ok(bids);
    }).ProducesProblem(404).Produces<BidDto[]>(StatusCodes.Status200OK);
    app.MapPost("/house/{houseId:int}/bids", async(IBidRepository repo, int houseId,[FromBody] BidDto dto) => {
    if (dto.HouseId != houseId)
        return Results.Problem("No match", statusCode: StatusCodes.Status400BadRequest);
    if(!MiniValidator.TryValidate(dto, out var errors))
        return Results.ValidationProblem(errors);
    var newBid = await repo.Add(dto);
    return Results.Created($"/house/{newBid.HouseId}/bids", newBid);
    }).ProducesProblem(404).Produces<BidDto>(StatusCodes.Status201Created); 
    
    }
}