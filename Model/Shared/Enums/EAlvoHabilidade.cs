using System.ComponentModel;

namespace Model.Shared.Enums
{
    public enum EAlvoHabilidade
    {
        //[Description("Nenhum")]
        //Nenhum = 0,

        [Description("Si mesmo")]
        Self = 1,

        [Description("1 aliado")]
        UmAliado = 2,

        [Description("1 inimigo")]
        UmInimigo = 3
    }
}
