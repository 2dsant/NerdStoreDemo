﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStoreDemo.Catalogo.Application.Services;
using NerdStoreDemo.Vendas.Application.Commands;
using NerdStoreDemo.Core.Communication.Mediator;
using NerdStoreDemo.Core.Messages.CommonMessages.Notifications;

namespace NerdStoreDemo.WebApp.MVC.Controllers
{
    public class CarrinhoController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IMediatorHandler _mediatorHandler;

        public CarrinhoController(IProdutoAppService produtoAppService, IMediatorHandler mediatorHandler, INotificationHandler<DomainNotification> notification) 
            : base(notification, mediatorHandler)
        {
            _produtoAppService = produtoAppService;
            _mediatorHandler = mediatorHandler;
        }

        [Route("meu-carrinho")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        [Route("meu-carrinho")]
        public async Task<IActionResult> AdicionarItem(Guid id, int quantidade)
        {
            var produto = await _produtoAppService.ObterPorId(id);

            if (produto == null) return BadRequest();

            if (produto.QuantidadeEstoque < quantidade)
            {
                TempData["Erro"] = "Produto com estoque insuficiente";
                return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
            }

            var command = new AdicionarItemPedidoCommand(ClienteId, produto.Id, produto.Nome, quantidade, produto.Valor);
            await _mediatorHandler.EnviarComando(command);

            if (OperacaoValida())

            TempData["Erros"] = "Produto Indisponivel";
            return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
        }
    }
}
