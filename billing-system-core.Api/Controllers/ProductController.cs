using billing_system_core.Application.Products.Command;
using billing_system_core.Contracts.Product;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace billing_system_core.Api.Controllers;

[Route("api/v1/products")]
public class ProductController: ApiController
{
    private readonly IMapper _mapper;

    private readonly ISender _mediator;

    public ProductController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductRequest request)
    {
        var command = _mapper.Map<CreateProductCommand>(request);
        var productResult = await _mediator.Send(command);

        return productResult.Match(
            product => Ok(_mapper.Map<ProductResponse>(productResult.Value)),
            errors => Problem(errors));
    }
}