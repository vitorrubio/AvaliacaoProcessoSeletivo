using AvaliacaoProcessoSeletivo.Api.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AvaliacaoProcessoSeletivo.Api.Infra.Data
{

    public class Contexto : DbContext
	{
		public Contexto(DbContextOptions<Contexto> op) : base(op)
		{

		}



		#region Propriedade Base

		public virtual DbSet<Conta> Conta { get; set; }

		#endregion Propriedade Base


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			base.OnModelCreating(modelBuilder);
		}

		#region Configurações



		public override int SaveChanges()
		{
			try
			{
				return base.SaveChanges();
			}
			///<summary>Quando algum erro diferente foi apresentado e for possivel ser trantado incluir a tratativa</summary>
			catch (DbUpdateException due)
			{
				//armazena a mensagem de erro e as mensagens das duas exceptions interiores
				string mensagens = due.Message + " "
					+ due.InnerException?.Message + " "
					+ due.InnerException?.InnerException?.Message;

				throw;

			}

			catch (InvalidOperationException ioe)
			{


				throw;
			}
			catch (Exception ex)
			{

				throw;
			}


		}


		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			try
			{
				return base.SaveChangesAsync(cancellationToken);
			}
			///<summary>Quando algum erro diferente foi apresentado e for possivel ser trantado incluir a tratativa</summary>
			catch (DbUpdateException due)
			{
				//armazena a mensagem de erro e as mensagens das duas exceptions interiores
				string mensagens = due.Message + " "
					+ due.InnerException?.Message + " "
					+ due.InnerException?.InnerException?.Message;

				throw;

			}

			catch (InvalidOperationException ioe)
			{


				throw;
			}
			catch (Exception ex)
			{

				throw;
			}

		}

		#endregion
	}

}
