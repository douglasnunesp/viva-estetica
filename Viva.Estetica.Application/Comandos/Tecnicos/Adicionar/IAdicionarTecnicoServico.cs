﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viva.Estetica.Application.Comandos.Tecnicos.Adicionar
{
    public interface IAdicionarTecnicoServico
    {
        void Processa(AdicionarTecnicoComando comando);
    }
}
