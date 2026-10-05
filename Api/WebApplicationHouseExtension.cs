using Microsoft.AspNetCore.Mvc;
using MiniValidation;

public static class WebApplicationHouseExtension
{
 public static void MapHouseEndpoints(this WebApplication app)
    {
    app.MapGet("/houses",  (IHouseRepository repo) => repo.GetAll())
    .ProducesProblem(404).Produces<HouseDto[]>(StatusCodes.Status200OK);

app.MapGet("/house/{houseId:int}", async(IHouseRepository repo, int houseId) => {
    var house =await repo.Get(houseId);
    if (house==null)
        return Results.Problem($"House with ID {houseId} not found.",statusCode: 404);
    return Results.Ok(house);
}).ProducesProblem(404).Produces<HouseDetailDto>(StatusCodes.Status200OK);

app.MapPost("/houses", async(IHouseRepository repo,[FromBody] HouseDetailDto dto) => {
    if(!MiniValidator.TryValidate(dto, out var errors))
        return Results.ValidationProblem(errors);
  var newHouse=await repo.Add(dto);
  return Results.Created($"/house/{newHouse.Id}", newHouse);
}).ProducesProblem(404).Produces<HouseDetailDto>(StatusCodes.Status201Created)
  .ProducesValidationProblem();

app.MapPut("/houses", async(IHouseRepository repo,[FromBody] HouseDetailDto dto) => {
    if(!MiniValidator.TryValidate(dto, out var errors))
        return Results.ValidationProblem(errors);
    if (await repo.Get(dto.Id) == null)
        return Results.Problem("House {dto.id} not found.", statusCode: 404);
  var updatedHouse=await repo.Update(dto);
  return Results.Ok(updatedHouse);
}).ProducesProblem(404).Produces<HouseDetailDto>(StatusCodes.Status200OK)
  .ProducesValidationProblem();

app.MapDelete("/houses", async(IHouseRepository repo,[FromBody] HouseDetailDto dto) => {
    if (await repo.Get(dto.Id) == null)
        return Results.Problem("House {dto.id} not found.", statusCode: 404);
    await repo.Delete(dto.Id);
  return Results.Ok();
}).ProducesProblem(404).Produces<HouseDetailDto>(StatusCodes.Status200OK);


    }
}