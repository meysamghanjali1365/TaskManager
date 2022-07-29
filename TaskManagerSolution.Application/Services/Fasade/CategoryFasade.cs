using TaskManagerSolution.Application.Interfaces.IContexts;
using TaskManagerSolution.Application.Interfaces.IFasde;
using TaskManagerSolution.Application.Services.Commands.CategoryService.CreateCategory;
using TaskManagerSolution.Application.Services.Queries.CategoryService.GetAllCategory;

namespace TaskManagerSolution.Application.Services.Fasade;

public class CategoryFasade : ICategoryFasade {
    private readonly IDataBaseContext _context;

    public CategoryFasade(IDataBaseContext context) {
        _context = context;
    }
    private ICreateCategoryService _createCategoryService;
    public ICreateCategoryService CreateCategoryService {
        get {
            return _createCategoryService = _createCategoryService ?? new CreateCategoryService(_context);
        }
    }
    private IGetAllCategoryService _getAllCategoryService;
    public IGetAllCategoryService GetAllCategoryService {
        get {
            return _getAllCategoryService = _getAllCategoryService ?? new GetAllCategoryService(_context);
        }
    }
}