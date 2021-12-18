using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.InnovativeDevelops.Commands
{
    public class DeleteInnovativeDevelopByIdCommand : IRequest <int>
    {
        public int Id { get; set; }

        public class DeleteInnovativeDevelopByIdHandler : IRequestHandler<DeleteInnovativeDevelopByIdCommand, int>
        {
            private readonly ApplicationContext context;

            public DeleteInnovativeDevelopByIdHandler(ApplicationContext applicationContext)
            {
                context = applicationContext;
            }

            public async Task<int> Handle(DeleteInnovativeDevelopByIdCommand command, CancellationToken cancellationToken)
            {
                var innovative = context.InnovativeDevelopments.Where(it => it.Id == command.Id).FirstOrDefault();

                if(innovative == null)
                {
                    return default;
                }

                context.InnovativeDevelopments.Remove(innovative);
                await context.SaveChangesAsync();

                return innovative.Id;
            }
        }
    }
}
