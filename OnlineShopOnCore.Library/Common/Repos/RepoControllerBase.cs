using Microsoft.AspNetCore.Mvc;
using OnlineShopOnCore.Library.Common.Interfaces;
using OnlineShopOnCore.Library.Constants;

namespace OnlineShopOnCore.Library.Common.Repos
{
    public abstract class RepoControllerBase<T> : ControllerBase where T : IIdentifiable
    {
        protected readonly IRepo<T> EntitiesRepo;

        public RepoControllerBase(IRepo<T> entitiesRepo)
        {
            EntitiesRepo = entitiesRepo;
        }



        [HttpPost(RepoActions.Add)]
        public async Task<ActionResult> Add([FromBody] T entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var articleId = await EntitiesRepo.AddAsync(entity);
            return Ok(articleId);
        }

        [HttpPost(RepoActions.AddRange)]
        public async Task<ActionResult> Add([FromBody] IEnumerable<T> entities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var articlesId = await EntitiesRepo.AddRangeAsync(entities);
            return Ok(articlesId);
        }

        [HttpGet]
        public async Task<ActionResult> GetOne(Guid id)
        {
            var article = await EntitiesRepo.GetOneAsync(id);
            return Ok(article);
        }

        [HttpGet(RepoActions.GetAll)]
        public async Task<ActionResult> GetAll()
        {
            var articles = await EntitiesRepo.GetAllAsync();
            return Ok(articles);
        }

        [HttpPost(RepoActions.Remove)]
        public virtual async Task<ActionResult> Remove([FromBody] Guid id)
        {
            await EntitiesRepo.RemoveAsync(id);
            return NoContent();
        }

        [HttpPost(RepoActions.RemoveRange)]
        public virtual async Task<ActionResult> Remove([FromBody] IEnumerable<Guid> ids)
        {
            await EntitiesRepo.RemoveRangeAsync(ids);
            return NoContent();
        }

        [HttpPost(RepoActions.Update)]
        public virtual async Task<ActionResult> Update([FromBody] T entity)
        {
            if (!ModelState.IsValid) { BadRequest(ModelState.Values);}

            var entityToBeUpdate = await EntitiesRepo.GetOneAsync(entity.Id);

            if (entityToBeUpdate == null)
            {
                return BadRequest($"Entity whit Id = {entity.Id} was not found");
            }

            UpdateProperties(entity, entityToBeUpdate);

            await EntitiesRepo.SaveAsync(entityToBeUpdate);
            return Ok(entityToBeUpdate);
        }

        protected abstract void UpdateProperties(T entity, T entityToBeUpdate);
    }
}
