[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
    private readonly IRepository<Recipe> _repository;

    public RecipesController(IRepository<Recipe> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetRecipes()
    {
        return Ok(await _repository.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRecipe(int id)
    {
        var recipe = await _repository.GetById(id);
        if (recipe == null)
        {
            return NotFound();
        }
        return Ok(recipe);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRecipe([FromBody] Recipe recipe)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdRecipe = await _repository.Create(recipe);
        return CreatedAtAction(nameof(GetRecipe), new { id = createdRecipe.RecipeID }, createdRecipe);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRecipe(int id, [FromBody] Recipe recipe)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != recipe.RecipeID)
        {
            return BadRequest();
        }

        await _repository.Update(recipe);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecipe(int id)
    {
        await _repository.Delete(id);
        return NoContent();
    }
}