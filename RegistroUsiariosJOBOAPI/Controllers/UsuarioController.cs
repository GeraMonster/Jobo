using Microsoft.AspNetCore.Mvc;
using RegistroUsiariosJOBOAPI.Models;
using RegistroUsiariosJOBOAPI.Servicios;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    // GET: api/Usuario
    [HttpGet]
    public ActionResult<IEnumerable<Usuario>> GetAll()
    {
        return Ok(_usuarioService.GetAll());
    }

    // GET: api/Usuario/5
    [HttpGet("{id}")]
    public ActionResult<Usuario> GetById(int id)
    {
        var usuario = _usuarioService.GetById(id);
        if (usuario == null)
            return NotFound();
        return Ok(usuario);
    }

    // POST: api/Usuario
    [HttpPost]
    public ActionResult<Usuario> Add(Usuario usuario)
    {
        _usuarioService.Add(usuario);
        return CreatedAtAction(nameof(GetById), new { id = usuario.IdUsuario }, usuario);
    }

    // PUT: api/Usuario/5
    [HttpPut("{id}")]
    public IActionResult Update(int id, Usuario usuario)
    {
        if (id != usuario.IdUsuario)
            return BadRequest();

        var existing = _usuarioService.GetById(id);
        if (existing == null)
            return NotFound();

        _usuarioService.Update(usuario);
        return NoContent();
    }

    // DELETE: api/Usuario/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var usuario = _usuarioService.GetById(id);
        if (usuario == null)
            return NotFound();

        _usuarioService.Delete(id);
        return NoContent();
    }
}
