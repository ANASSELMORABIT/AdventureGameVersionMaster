public static class Play
{

    public static Jugador ElegirPersonajeEspecial(ref Jugador jugador)
    {


        // Mostrar opciones de personajes especiales
        DecoracionUtils.MostrarMensajeEstilado("Choose your new character: 👑");
        DecoracionUtils.MostrarMensajeEstilado("1. Mago");
        DecoracionUtils.MostrarMensajeEstilado("2. Arquero");
        DecoracionUtils.MostrarMensajeEstilado("3. Guerrero");
        DecoracionUtils.MostrarMensajeEstilado("4. No Special Character");

        int opcionPersonaje = Convert.ToInt32(Console.ReadLine());

        // Asignar el personaje especial según la opción del jugador
        switch (opcionPersonaje)
        {
            case 1:
                DecoracionUtils.MostrarMensajeEstilado("You've chosen the Mago! 🔮");
                if (jugador is Mago) // Si ya es un Mago, no es necesario cambiar
                {
                    DecoracionUtils.MostrarMensajeEstilado("You are already a Mago!");
                }
                else
                {
                    // Actualizar el jugador a un Mago sin perder la referencia
                    jugador = new Mago(jugador.nombre, jugador.puntosDeHabilidad)
                    {
                        nivel = jugador.nivel,
                        enemigosDerrotados = jugador.enemigosDerrotados,
                        puntosTotales = jugador.puntosTotales
                    };
                }
                break;

            case 2:
                DecoracionUtils.MostrarMensajeEstilado("You've chosen the Arquero! 🏹");
                if (jugador is Arquero) // Si ya es un Arquero, no es necesario cambiar
                {
                    DecoracionUtils.MostrarMensajeEstilado("You are already an Arquero!");
                }
                else
                {
                    // Actualizar el jugador a un Arquero sin perder la referencia
                    jugador = new Arquero(jugador.nombre, jugador.puntosDeHabilidad)
                    {
                        nivel = jugador.nivel,
                        enemigosDerrotados = jugador.enemigosDerrotados,
                        puntosTotales = jugador.puntosTotales

                    };
                }
                break;

            case 3:
                DecoracionUtils.MostrarMensajeEstilado("You've chosen the Guerrero! ⚔️");
                if (jugador is Guerrero) // Si ya es un Guerrero, no es necesario cambiar
                {
                    DecoracionUtils.MostrarMensajeEstilado("You are already a Guerrero!");
                }
                else
                {
                    // Actualizar el jugador a un Guerrero sin perder la referencia
                    jugador = new Guerrero(jugador.nombre, jugador.puntosDeHabilidad)
                    {
                        nivel = jugador.nivel,
                        enemigosDerrotados = jugador.enemigosDerrotados,
                        puntosTotales = jugador.puntosTotales
                    };
                }
                break;

            case 4:
                DecoracionUtils.MostrarMensajeEstilado("You've chosen not to choose a special character.");
                break;

            default:
                DecoracionUtils.MostrarMensajeEstilado("Invalid choice. The game will continue with the default character.");
                break;
        }

        return jugador;  // Retornar el mismo jugador actualizado, manteniendo la referencia
    }
    public static bool JugarPerimaraMapa(ref Jugador jugador, List<string> frasesMotivadoras)
    {
        List<EnemigoBasico> enemigos = new List<EnemigoBasico>();

        enemigos.Add(new EnemigoBasico("Sombra Oscura"));
        enemigos.Add(new EnemigoBasico("Espectro Menor"));
        enemigos.Add(new EnemigoBasico("Goblin Verde"));
        enemigos.Add(new EnemigoBasico("Huesos Marchitos"));
        enemigos.Add(new EnemigoBasico("Bandido Errante"));
        enemigos.Add(new EnemigoBasico("Zombie Despistado"));


    


        Random random = new Random();

        DecoracionUtils.MostrarMensajeEstilado("The player is about to embark on an adventure in the first Map.");

        RegistroMapas.Mapas[0].AboutMapa();



        foreach (EnemigoBasico EnemigoBasico in enemigos)
        {
            string fraseAleatoria = frasesMotivadoras[random.Next(frasesMotivadoras.Count)];

            DecoracionUtils.MostrarMensajeEstilado(fraseAleatoria);

            if (!JugarContraEnemigoBasico(ref jugador, EnemigoBasico)){
                MostrarTablaFinal(ref jugador);
                return false;   
            } 


            if (jugador.nivel % 3 == 0)
            {
                DecoracionUtils.MostrarMensajeEstilado("🎉 Congratulations! You've passed three turns without losing and can choose one of the Special Characters!");
                jugador = ElegirPersonajeEspecial(ref jugador);
            }
        }

        MostrarTablaFinal(ref jugador);
        return true;
    }


    public static bool JugarContraEnemigoBasico(ref Jugador jugador, EnemigoBasico enemigoBasico)
    {
        DecoracionUtils.MostrarMensajeEstilado("The player is about to face a basic enemy! ⚔️");

        DecoracionUtils.MostrarMensajeEstilado("Player's Status: 💪");
        jugador.ShowInfo();
        DecoracionUtils.MostrarMensajeEstilado("Enemy's Status: 🧟");
        enemigoBasico.ShowInfo();

        // Verificar si el jugador tiene ventaja automática por nivel
        if (jugador.nivel > enemigoBasico.nivel)
        {
            DecoracionUtils.MostrarMensajeEstilado("The player's level is higher than the enemy's! You've won automatically! 🎉");
            jugador.SubirPuntosDeHabilidad(); // Premiar al jugador por la victoria
            jugador.IncrementarTurnosDesdeUltimaHabilidad();
            if (enemigoBasico.OtorgarPuntoHabilidad()) jugador.puntosDeHabilidad++;
            return true; // Terminar la función
        }

        bool juegoEnCursoEnemigobasico = true;

        while (juegoEnCursoEnemigobasico)
        {
            // Evento sorpresa después de cada turno del jugador (puedes ajustarlo como prefieras)
            EventoSorpresa(ref jugador);


            // Turno del jugador
            DecoracionUtils.MostrarMensajeEstilado("Press any key to Attack... ⏳");
            Console.ReadKey();
            int tiradaJugador;

            // Aquí entramos en el switch para manejar las diferentes clases de jugador
            switch (jugador)
            {
                case Arquero arquero when arquero.turnosDesdeAtaqueDoble >= 3:
                    // Lógica para el Arquero con ataque doble disponible
                    string decision = null;
                    bool decisionValida = false;

                    while (!decisionValida)
                    {
                        try
                        {
                            DecoracionUtils.MostrarMensajeEstilado("Do you want to use the double attack? (y/n)");
                            decision = Console.ReadLine()?.ToLower();

                            if (decision != "y" && decision != "n")
                            {
                                throw new ArgumentException("The input must be 'y' or 'n'.");
                            }

                            decisionValida = true; // Entrada válida
                        }
                        catch (ArgumentException ex)
                        {
                            DecoracionUtils.MostrarMensajeEstilado($"❌ {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            DecoracionUtils.MostrarMensajeEstilado($"❌ Unexpected error: {ex.Message}");
                        }
                    }

                    tiradaJugador = decision == "y" ? arquero.AtacarDoble() : arquero.Atacar();
                    if (decision != "y") arquero.IncrementarTurnosDesdeAtaqueDoble();
                    break;

                case Arquero arquero:
                    // Lógica para el Arquero sin ataque doble
                    tiradaJugador = arquero.Atacar();
                    arquero.IncrementarTurnosDesdeAtaqueDoble();
                    break;

                case Guerrero guerrero:
                    // Lógica para el Guerrero: Siempre ataca en su turno
                    tiradaJugador = guerrero.Atacar();
                    guerrero.IncrementarTurnosDesdeBloqueo();
                    break;

                case Mago magoJugador:
                    // Lógica para el Mago
                    tiradaJugador = magoJugador.Atacar();
                    magoJugador.IncrementarTurnosRecuperacionVida(); // Incrementamos los turnos de recuperación de vida
                    break;

                default:
                    // Lógica por defecto para otros tipos de jugadores
                    tiradaJugador = jugador.Atacar();
                    break;
            }

            // Mostrar el resultado del ataque del jugador
            if (tiradaJugador > 0)
            {
                DecoracionUtils.MostrarMensajeEstilado($"The player strikes, dealing {tiradaJugador} points of damage! ⚡");
                enemigoBasico.RecibirDano(tiradaJugador);
            }

            // Verificar si el enemigo fue derrotado
            if (!enemigoBasico.EstaVivo())
            {
                if (jugador is Mago magoJugador)
                {
                    magoJugador.RecuperarVida(); // Recuperar vida si el mago derrota al enemigo
                }

                DecoracionUtils.MostrarMensajeEstilado("🏆 Crushing victory! You have proven yourself a true warrior. 🌟 Level up achieved! You're now stronger, faster, and wiser.");
                jugador.SubirPuntosDeHabilidad(); // Premiar al jugador por derrotar al enemigo
                if (enemigoBasico.OtorgarPuntoHabilidad()) jugador.puntosDeHabilidad++;
                return true; // Terminar el juego
            }

            // Evento sorpresa después de cada turno del enemigo (puedes ajustarlo también)
            EventoSorpresa(ref jugador);

            // Turno del enemigo
            int tiradaEnemigo = enemigoBasico.Atacar();

            // Verificar si el Guerrero puede bloquear el ataque enemigo
            if (jugador is Guerrero guerreroBloqueo && guerreroBloqueo.TurnosDesdeBloqueo >= 3)
            {
                DecoracionUtils.MostrarMensajeEstilado("Do you want to block the enemy's attack? (y/n)");
                string bloqueDecision = Console.ReadLine()?.ToLower();

                if (bloqueDecision == "y" && guerreroBloqueo.BloquearAtaque())
                {
                    DecoracionUtils.MostrarMensajeEstilado("🛡️ The enemy's attack was blocked!");
                    tiradaEnemigo = 0; // Bloquea el daño del enemigo
                    guerreroBloqueo.ResetTurnosDesdeUltimaHabilidad(); // Reiniciar contador de turnos
                }
            }

            // Aplicar daño si el ataque no fue bloqueado
            if (tiradaEnemigo > 0)
            {
                DecoracionUtils.MostrarMensajeEstilado($"The enemy strikes, dealing {tiradaEnemigo} points of damage! 💥");
                jugador.RecibirDano(tiradaEnemigo);
            }

            // Verificar si el jugador fue derrotado
            if (!jugador.EstaVivo())
            {
                DecoracionUtils.MostrarMensajeEstilado("💔 You've fallen in this battle, but there's still much fight left in you. Rise again!");
                return false; // Terminar el juego
            }

            // Incrementar contadores de habilidades
            if (jugador is Mago mago)
            {
                mago.IncrementarTurnosRecuperacionVida(); // Incrementar los turnos de recuperación de vida
            }
        }

        DecoracionUtils.MostrarMensajeEstilado("The battle with the Basic enemy has come to an end. 🎉");

        

        
        return true;
    }

    public static bool JugarSegundoMapa(ref Jugador jugador, List<string> frasesMotivadoras)
    {
        subirHablidades(ref jugador, 2); // Subir habilidades del jugador
        
        List<EnemigoEspecial> enemigos = new List<EnemigoEspecial>();

        enemigos.Add(new EnemigoEspecial("Orco Juvenil"));
        enemigos.Add(new EnemigoEspecial("Zombie Despistado"));
        enemigos.Add(new EnemigoEspecial("Murciélago Nocturno"));
        enemigos.Add(new EnemigoEspecial("Esqueleto Frágil"));
        enemigos.Add(new EnemigoEspecial("Araña Venenosa"));

        Random random = new Random();
        DecoracionUtils.MostrarMensajeEstilado("The player is about to embark on an adventure in the Second Map.");

        RegistroMapas.Mapas[1].AboutMapa();

        foreach (EnemigoEspecial EnemigoEspecial in enemigos)
        {
            string fraseAleatoria = frasesMotivadoras[random.Next(frasesMotivadoras.Count)];
            DecoracionUtils.MostrarMensajeEstilado(fraseAleatoria);
            if (!JugarContraEnemigoEspecial(ref jugador, EnemigoEspecial))
            {
                MostrarTablaFinal(ref jugador);
                return false;
            }
            if (jugador.nivel % 3 == 0)
            {
                jugador = ElegirPersonajeEspecial(ref jugador);
            }


        }

        MostrarTablaFinal(ref jugador);

        return true;

    }

    public static bool JugarContraEnemigoEspecial(ref Jugador jugador, EnemigoEspecial enemigoEspecial)
    {
        DecoracionUtils.MostrarMensajeEstilado("The player is about to face a special enemy! ⚔️");

        DecoracionUtils.MostrarMensajeEstilado("Player's Status: 💪");
        jugador.ShowInfo();
        DecoracionUtils.MostrarMensajeEstilado("Enemy's Status: 🧟");
        enemigoEspecial.ShowInfo();

        // Verificar si el jugador tiene ventaja automática por nivel
        if (jugador.nivel > enemigoEspecial.nivel)
        {
            DecoracionUtils.MostrarMensajeEstilado("The player's level is higher than the enemy's! You've won automatically! 🎉");
            jugador.SubirPuntosDeHabilidad(); // Premiar al jugador por la victoria
            jugador.SubirPuntosDeHabilidad();
            if (enemigoEspecial.OtorgarPuntoHabilidad()) jugador.puntosDeHabilidad++;
            return true; // Terminar la función
        }

        bool juegoEnCurso = true;

        while (juegoEnCurso)
        {
            // Evento sorpresa después de cada turno del jugador
            EventoSorpresa(ref jugador);

            // Turno del jugador
            DecoracionUtils.MostrarMensajeEstilado("Press any key to Attack... ⏳");
            Console.ReadKey();
            int tiradaJugador;

            // Aquí entramos en el switch para manejar las diferentes clases de jugador
            switch (jugador)
            {
                case Arquero arquero when arquero.turnosDesdeAtaqueDoble >= 3:
                    // Lógica para el Arquero con ataque doble disponible
                    string decision = null;
                    bool decisionValida = false;

                    while (!decisionValida)
                    {
                        try
                        {
                            DecoracionUtils.MostrarMensajeEstilado("Do you want to use the double attack? (y/n)");
                            decision = Console.ReadLine()?.ToLower();

                            if (decision != "y" && decision != "n")
                            {
                                throw new ArgumentException("The input must be 'y' or 'n'.");
                            }

                            decisionValida = true; // Entrada válida
                        }
                        catch (ArgumentException ex)
                        {
                            DecoracionUtils.MostrarMensajeEstilado($"❌ {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            DecoracionUtils.MostrarMensajeEstilado($"❌ Unexpected error: {ex.Message}");
                        }
                    }

                    tiradaJugador = decision == "y" ? arquero.AtacarDoble() : arquero.Atacar();
                    if (decision != "y") arquero.IncrementarTurnosDesdeAtaqueDoble();
                    break;

                case Arquero arquero:
                    // Lógica para el Arquero sin ataque doble
                    tiradaJugador = arquero.Atacar();
                    arquero.IncrementarTurnosDesdeAtaqueDoble();
                    break;

                case Guerrero guerrero:
                    // Lógica para el Guerrero: Siempre ataca en su turno
                    tiradaJugador = guerrero.Atacar();
                    guerrero.IncrementarTurnosDesdeBloqueo();
                    break;

                case Mago magoJugador:
                    // Lógica para el Mago
                    tiradaJugador = magoJugador.Atacar();
                    magoJugador.IncrementarTurnosRecuperacionVida();
                    break;

                default:
                    // Lógica por defecto para otros tipos de jugadores
                    tiradaJugador = jugador.Atacar();
                    break;
            }

            // Mostrar el resultado del ataque del jugador
            if (tiradaJugador > 0)
            {
                DecoracionUtils.MostrarMensajeEstilado($"The player strikes, dealing {tiradaJugador} points of damage! ⚡");
                enemigoEspecial.RecibirDano(tiradaJugador);
            }

            // Verificar si el enemigo fue derrotado
            if (!enemigoEspecial.EstaVivo())
            {
                if (jugador is Mago magoJugador)
                {
                    magoJugador.RecuperarVida();
                }

                DecoracionUtils.MostrarMensajeEstilado("🏆 Crushing victory! You have proven yourself a true warrior. 🌟 Level up achieved! You're now stronger, faster, and wiser.");
                jugador.SubirPuntosDeHabilidad(); // Premiar al jugador por derrotar al enemigo
                if (enemigoEspecial.OtorgarPuntoHabilidad()) jugador.puntosDeHabilidad++;
                return true; // Terminar el juego
            }

            // Evento sorpresa después de cada turno del enemigo
            EventoSorpresa(ref jugador);

            // Turno del enemigo
            int tiradaEnemigo = enemigoEspecial.Atacar();

            // Verificar si el Guerrero puede bloquear el ataque enemigo
            if (jugador is Guerrero guerreroBloqueo && guerreroBloqueo.TurnosDesdeBloqueo >= 3)
            {
                DecoracionUtils.MostrarMensajeEstilado("Do you want to block the enemy's attack? (y/n)");
                string bloqueDecision = Console.ReadLine()?.ToLower();

                if (bloqueDecision == "y" && guerreroBloqueo.BloquearAtaque())
                {
                    DecoracionUtils.MostrarMensajeEstilado("🛡️ The enemy's attack was blocked!");
                    tiradaEnemigo = 0; // Bloquea el daño del enemigo
                    guerreroBloqueo.ResetTurnosDesdeUltimaHabilidad(); // Reiniciar contador de turnos
                }
            }

            // Aplicar daño si el ataque no fue bloqueado
            if (tiradaEnemigo > 0)
            {
                DecoracionUtils.MostrarMensajeEstilado($"The enemy strikes, dealing {tiradaEnemigo} points of damage! 💥");
                jugador.RecibirDano(tiradaEnemigo);
            }

            // Verificar si el jugador fue derrotado
            if (!jugador.EstaVivo())
            {
                DecoracionUtils.MostrarMensajeEstilado("💔 You've fallen in this battle, but there's still much fight left in you. Rise again!");
                return false; // Terminar el juego
            }

            // Incrementar contadores de habilidades
            if (jugador is Mago mago)
            {
                mago.IncrementarTurnosRecuperacionVida();
            }
        }



        DecoracionUtils.MostrarMensajeEstilado("The battle with the special enemy has come to an end. 🎉");

       

        return true;
    }




    public static bool JugarTercerMapa(ref Jugador jugador, List<string> frasesMotivadoras)
    {

        Boss boss = new Boss("The Final Boss");

      

        subirHablidades(ref jugador, 3);

        DecoracionUtils.MostrarMensajeEstilado("The player is about to embark on an adventure in the Third Map.");

        RegistroMapas.Mapas[2].AboutMapa();

        DecoracionUtils.MostrarMensajeEstilado("The player is about to face the Final Boss! ⚔️");

        jugador = ElegirPersonajeEspecial(ref jugador);


        Random random = new Random();





        string fraseAleatoria = frasesMotivadoras[random.Next(frasesMotivadoras.Count)];

        DecoracionUtils.MostrarMensajeEstilado(fraseAleatoria);

        if (!JugarContraBoss(ref jugador, boss)){
            MostrarTablaFinal(ref jugador);
            return false;
        } 


        MostrarTablaFinal(ref jugador);
        return true;


    }


    public static bool JugarContraBoss(ref Jugador jugador, Boss boss)
    {
        
        


        DecoracionUtils.MostrarMensajeEstilado("🔥 The ultimate battle begins! Prepare yourself! 🔥");

        // Mostrar estado inicial del jugador y del boss
        DecoracionUtils.MostrarMensajeEstilado("Player's Status: 💪");
        jugador.ShowInfo();
        DecoracionUtils.MostrarMensajeEstilado("Boss's Status: 👹");
        boss.ShowInfo();

        bool combateEnCurso = true;

        while (combateEnCurso)
        {
            // *** Turno del jugador ***
            DecoracionUtils.MostrarMensajeEstilado("Press any key to launch your attack... ⏳");
            Console.ReadKey();
            int tiradaJugador;

            // Determinar la acción del jugador según su tipo
            switch (jugador)
            {
                case Guerrero guerrero:
                    // El Guerrero siempre ataca en su turno
                    tiradaJugador = guerrero.Atacar();
                    guerrero.IncrementarTurnosDesdeBloqueo();
                    break;

                case Arquero arquero when arquero.turnosDesdeAtaqueDoble >= 3:
                    // Decidir si usar ataque doble del Arquero
                    DecoracionUtils.MostrarMensajeEstilado("Do you want to use a double attack? (y/n)");
                    string decisionAtaqueDoble = Console.ReadLine()?.ToLower();

                    tiradaJugador = decisionAtaqueDoble == "y" ? arquero.AtacarDoble() : arquero.Atacar();
                    if (decisionAtaqueDoble != "y") arquero.IncrementarTurnosDesdeAtaqueDoble();
                    break;

                case Arquero arquero:
                    tiradaJugador = arquero.Atacar();
                    arquero.IncrementarTurnosDesdeAtaqueDoble();
                    break;

                case Mago mago:
                    tiradaJugador = mago.Atacar();
                    mago.IncrementarTurnosRecuperacionVida(); // Incrementar contador de recuperación
                    break;

                default:
                    tiradaJugador = jugador.Atacar(); // Ataque genérico
                    break;
            }

            // Mostrar resultado del ataque del jugador
            if (tiradaJugador > 0)
            {
                DecoracionUtils.MostrarMensajeEstilado($"The player strikes the Boss, dealing {tiradaJugador} points of damage! ⚡");
                boss.RecibirDano(tiradaJugador);
            }

            // Verificar si el Boss ha sido derrotado
            if (!boss.EstaVivo())
            {
                DecoracionUtils.MostrarMensajeEstilado("🎉 Victory! You've defeated the Final Boss! The realm is saved!");
                
                jugador.SubirPuntosDeHabilidad();

            
                return true;
            }

            // *** Turno del Boss ***
            boss.IncrementarTurnos(); // Incrementar contador de regeneración

            // Decidir si el Boss regenera vida
            if (boss.turnosDesdeUltimaRegeneracion >= 3)
            {
                DecoracionUtils.MostrarMensajeEstilado("The Boss regenerates some of its health! 💖");
                boss.RegenerarVida();
            }

            // El Boss realiza un ataque
            int tiradaBoss = boss.Atacar();
            DecoracionUtils.MostrarMensajeEstilado($"The Boss unleashes a ferocious attack, dealing {tiradaBoss} points of damage! 💥");

            // Verificar si el Guerrero puede bloquear
            if (jugador is Guerrero guerreroBloqueo && guerreroBloqueo.TurnosDesdeBloqueo >= 3)
            {
                DecoracionUtils.MostrarMensajeEstilado("Do you want to block the Boss's attack? (y/n)");
                string decisionBloqueo = Console.ReadLine()?.ToLower();

                if (decisionBloqueo == "y" && guerreroBloqueo.BloquearAtaque())
                {
                    DecoracionUtils.MostrarMensajeEstilado("🛡️ The player's block nullifies the Boss's attack!");
                    tiradaBoss = 0; // Bloquear el daño del Boss
                    guerreroBloqueo.ResetTurnosDesdeUltimaHabilidad(); // Reiniciar contador de turnos
                }
            }

            // Aplicar daño si el ataque no fue bloqueado
            if (tiradaBoss > 0)
            {
                jugador.RecibirDano(tiradaBoss);
            }

            // Verificar si el jugador ha sido derrotado
            if (!jugador.EstaVivo())
            {
                DecoracionUtils.MostrarMensajeEstilado("💔 The Boss has defeated you. Rise again and try once more.");
                return false;
            }
        }

        return false; // No debería alcanzarse si el combate está correctamente gestionado
    }

    public static void subirHablidades(ref Jugador jugador, int mapaActual)
    {
        //Si el jugador ha llegado a la mapa 3, subir habilidades y el nivel
        if (mapaActual == 2)
        {
            jugador.puntosDeHabilidad = jugador.puntosDeHabilidad + 2; // Suma 2 puntos de habilidad
            jugador.nivel = jugador.nivel + 3; // Suma 3 niveles
            jugador.puntosVida = jugador.puntosVida + 5; // Suma 5 puntos de vida

        }

        if (mapaActual == 3)
        {
            jugador.puntosDeHabilidad = jugador.puntosDeHabilidad + 3; // Suma 3 puntos de habilidad
            jugador.nivel = jugador.nivel + 4; // Suma 4 niveles
            jugador.puntosVida = jugador.puntosVida + 7; // Suma 7 puntos de vida
        }
    }



    static void EventoSorpresa(ref Jugador jugador)
    {
        Random random = new Random();
        int evento = random.Next(1, 4); // Generar un número aleatorio entre 1 y 3

        switch (evento)
        {
            case 1: // Trampa
                DecoracionUtils.MostrarMensajeEstilado("💥 You've fallen into a trap! You lose 3 health points.");
                if(jugador.puntosVida <= 3){
                    jugador.puntosVida = 4; //las trampas no deben matar al jugador
                }
                jugador.RecibirDano(3);
                break;
            case 2: // Cofre
                DecoracionUtils.MostrarMensajeEstilado("🎁 You've found a chest! You gain 10 health points.");
                jugador.puntosVida = jugador.puntosVida + 10;

                break;
            case 3: // Evento positivo
                DecoracionUtils.MostrarMensajeEstilado("✨ A benevolent spirit grants you an extra skill point.");
                jugador.puntosDeHabilidad = jugador.puntosDeHabilidad + 1;
                break;
        }
    }

    public static void MostrarTablaFinal(ref Jugador jugador)
    {
        // Decorar la tabla final con bordes y formato estilizado
        string titulo = "🏆 Final Scoreboard 🏆";
        string[] contenido = {
        $"👤 Player: {jugador.nombre}",
        $"🔢 Level: {jugador.nivel}",
        $"👾 Enemies Defeated: {jugador.enemigosDerrotados}",
        $"🏅 Total Points: {jugador.puntosTotales}",  // Mostrar puntos totales
    };

        // Llamamos al método de decoración para mostrar la tabla estilizada
        DecoracionUtils.MostrarConBordes(titulo, contenido);
    }

    


}