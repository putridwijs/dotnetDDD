using billing_system_core.Application.ProductCategories.Command;
using billing_system_core.Application.ProductCategories.Command.Create;
using billing_system_core.Application.ProductCategories.Command.Delete;
using billing_system_core.Application.ProductCategories.Command.Update;
using billing_system_core.Application.ProductCategories.Query;
using billing_system_core.Application.ProductCategories.Query.GetAll;
using billing_system_core.Application.ProductCategories.Query.GetDetail;
using billing_system_core.Contracts.ProductCategories;
using billing_system_core.Domain.ProductCategoryAggregate;
using billing_system_core.Domain.ProductCategoryAggregate.ValueObjects;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace billing_system_core.Api.Controllers;

[Route("api/v1/product-categories")]
public class ProductCategoryController: ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public ProductCategoryController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductCategory(
        CreateProductCategoryRequest request)
    {
        var command = _mapper.Map<CreateProductCategoryCommand>(request);
        var createProductCategoryResult = await _mediator.Send(command);
        
        return createProductCategoryResult.Match(
            productCategory => Ok(_mapper.Map<ProductCategoryResponse>(createProductCategoryResult.Value)),
            errors => Problem(errors));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetailProductCategory(Guid id)
    {
        var command = new GetDetailProductCategoryQuery(id);
        var result = await _mediator.Send(command);

        return result.Match(
            response => Ok(_mapper.Map<ProductCategoryResponse>(result.Value)),
            errors => Problem(errors));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProductCategory()
    {
        var command = new GetAllProductCategoryQuery();
        var result = await _mediator.Send(command);

        return result.Match(
            response => Ok(_mapper.Map<List<ProductCategoryResponse>>(result.Value)),
            errors => Problem(errors));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductCategory(Guid id, UpdateProductCategoryRequest request)
    {
        var req = new UpdateProductCategoryRequest(
            request.Name,
            request.Type,
            request.ParentCategory,
            request.Companies,
            request.OneItemPerOrder,
            request.OneItemPerCustomer,
            request.AllowAssetManagement,
            request.UpdatedBy,
            id);
        var command = _mapper.Map<UpdateProductCategoryCommand>(req);
        var result = await _mediator.Send(command);

        return result.Match(
            response => Ok(result.Value),
            errors => Problem(errors));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductCategory(Guid id)
    {
        var command = new DeleteProductCategoryCommand(id);
        var result = await _mediator.Send(command);
        
        return result.Match(
            response => Ok(result.Value),
            errors => Problem(errors));
    }
}