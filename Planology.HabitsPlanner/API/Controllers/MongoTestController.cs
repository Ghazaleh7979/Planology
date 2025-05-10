using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/[controller]")]
public class MongoTestController : ControllerBase
{
    private readonly IMongoDatabase _db;

    public MongoTestController(IMongoDatabase db)
    {
        _db = db;
    }

    [HttpGet("collections")]
    public IActionResult GetCollections()
    {
        var collections = _db.ListCollectionNames().ToList();
        return Ok(collections);
    }
}
