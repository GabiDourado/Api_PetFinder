﻿using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepositorio _usuariosRepositorio;

        public UsuariosController(IUsuariosRepositorio usuariosRepositorio)
        {
            _usuariosRepositorio = usuariosRepositorio;
        }
        [HttpGet("GetAllUsuarios")]
        public async Task<ActionResult<List<UsuariosModel>>> GetAllUsuarios()
        {
            List<UsuariosModel> usuarios = await _usuariosRepositorio.GetAll();
            return Ok(usuarios);
        }
        [HttpGet("GetUsuarioId/{id}")]
        public async Task<ActionResult<UsuariosModel>> GetUsuarioId(int id)
        {
            UsuariosModel usuario = await _usuariosRepositorio.GetById(id);
            return Ok(usuario);
        }
        [HttpPost("InsertUsuario")]
        public async Task<ActionResult<UsuariosModel>> InsertUsuario([FromBody] UsuariosModel usuarioModel)
        {
            UsuariosModel usuario = await _usuariosRepositorio.InsertUsuario(usuarioModel);
            return Ok(usuario);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UsuariosModel>> Login([FromBody] UsuariosModel usuarioModel)
        {
            UsuariosModel usuario = await _usuariosRepositorio.Login(usuarioModel.UsuarioEmail, usuarioModel.UsuarioSenha);
            return Ok(usuario);
            
        }

        [HttpPut("UpdateUsuario/{id:int}")]
        public async Task<ActionResult<UsuariosModel>> UpdateUsuario(int id, [FromBody] UsuariosModel usuarioModel)
        {
            usuarioModel.UsuarioId = id;
            UsuariosModel usuario = await _usuariosRepositorio.UpdateUsuario(usuarioModel, id);
            return Ok(usuario);
        }
        [HttpDelete("DeleteUsuario/{id:int}")]
        public async Task<ActionResult<UsuariosModel>> DeleteUsuario(int id)
        {
            bool deleted = await _usuariosRepositorio.DeleteUsuario(id);
            return Ok(deleted);
        }
    }
}
