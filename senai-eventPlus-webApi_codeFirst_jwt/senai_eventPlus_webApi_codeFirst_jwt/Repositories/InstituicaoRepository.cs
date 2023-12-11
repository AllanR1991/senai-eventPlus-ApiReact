using senai_eventPlus_webApi_codeFirst_jwt.Contexts;
using senai_eventPlus_webApi_codeFirst_jwt.Domains;
using senai_eventPlus_webApi_codeFirst_jwt.Interfaces;

namespace senai_eventPlus_webApi_codeFirst_jwt.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        EventPlusContext context = new EventPlusContext();

        public void Alterar(Guid id, Instituicao instituicaoAlterado)
        {
            Instituicao instituicaoBuscado = context.Instituicao.FirstOrDefault(i => i.idInstituicao == id);

            if (instituicaoAlterado.cnpj != null)
            {
                instituicaoBuscado.cnpj = instituicaoAlterado.cnpj;
            }
            if (instituicaoAlterado.endereco != null)
            {
                instituicaoBuscado.endereco = instituicaoAlterado.endereco;
            }
            if (instituicaoAlterado.razaoSocial != null)
            {
                instituicaoBuscado.razaoSocial = instituicaoAlterado.razaoSocial;
            }
            if (instituicaoAlterado.nomeFantasia != null)
            {
                instituicaoBuscado.nomeFantasia = instituicaoAlterado.nomeFantasia;
            }

            context.Instituicao.Update(instituicaoBuscado);

            context.SaveChanges();
        }

        public void Cadastrar(Instituicao novaInstituicao)
        {
            context.Instituicao.Add(novaInstituicao);

            context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Instituicao instituicaoEncontrado = context.Instituicao.FirstOrDefault(i => i.idInstituicao == id);

            context.Instituicao.Remove(instituicaoEncontrado);

            context.SaveChanges();

        }

        public Instituicao ListarPorId(Guid id)
        {
            return context.Instituicao.FirstOrDefault(i => i.idInstituicao == id);
        }

        public List<Instituicao> Listartodos()
        {
            return context.Instituicao.ToList();
        }
    }
}
