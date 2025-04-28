using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Models;
using RpgApi.Models.Enuns;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonagensExercicioController : ControllerBase
    {
        //Lista de Personagens
 private static List<Personagem> personagens = new List<Personagem>()
        {
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };
        [HttpGet("GetByNome/{nome}")]
        public IActionResult GetByNome(string nome)
        {
            Personagem p = personagens.FirstOrDefault(p => p.Nome.ToLower() == nome.ToLower());
            if (p == null)
            {
                return NotFound(new { mensagem = "Personagem não encontrado" });
            }else{
                return Ok(p);
            }
        }
        [HttpGet("GetClerigoMago")]
        public IActionResult GetClericoMago()
        {
            var lista = personagens.Where(p => p.Classe == ClasseEnum.Cavaleiro)
                .OrderByDescending(p => p.PontosVida)
                .ToList();
            return Ok(lista);
        }
        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstatisticas()
        {
           int num_personagens = personagens.Count;
           int sum_inteligencia = personagens.Sum(p => p.Inteligencia);
                return Ok(new { num_personagens, sum_inteligencia });
        }
        [HttpPost("PostValidacao")]
        public IActionResult PostValidacao(Personagem personagem){
            if (personagem.Defesa < 10 || personagem.Inteligencia > 30)
            {
                return BadRequest(new { mensagem = "Personagem não tem os valores nescessários para ser adicionado"});
            }else{
                personagens.Add(personagem);
                return Ok(personagens);
            }
        }
        [HttpPost("PostValidacaoMago")]
        public IActionResult PostValidacaoMago(Personagem personagem){
            if(personagem.Classe == ClasseEnum.Mago){
                if(personagem.Inteligencia < 35){
                    return BadRequest(new { mensagem = "Personagem não tem os valores nescessários para ser adicionado"});
                }else{
                    personagens.Add(personagem);
                    return Ok();
                }
            }else{
                return BadRequest(new { mensagem = "Personagem não é um Mago"});
            }
        }
        [HttpGet("GetByClasse/{idClasse}")]
        public IActionResult GetByClasse(int IdClasse)
        {
            ClasseEnum tipoEnum = (ClasseEnum)IdClasse;

            var lista = personagens.Where(p => (int)p.Classe == IdClasse).ToList();
            return Ok(lista);
        }
    }
}