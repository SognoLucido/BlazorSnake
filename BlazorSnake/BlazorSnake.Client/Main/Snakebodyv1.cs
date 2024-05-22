namespace BlazorSnake.Client.Main
{
    public class Snakebodyv1
    {

        public event EventHandler? DataUpdater;

        public List<int> NumbersSet { get; private set; } = [55];


        public bool GameStarted { get; private set; } = false;
        public bool GameFinished { get; private set; } = false;

        public bool Restart { get; set; }
        public int Score { get; private set; } = 0;

        private int Speed { get; set; } = 500;


        public bool ValueSubmit { get; set; } = false;

        public int Foodposition { get; private set; } = 0;
        //EventHandler Update();

        private Snake Cdirection = Snake.s;


        private void Genfood()
        {
            Random random = new();


            do
            {
                Foodposition = (random.Next(10, 100));

            }
            while (NumbersSet.Contains(Foodposition));



        }



        public CancellationTokenSource cancellationTokenSource = new();

        //static CancellationTokenSource cancellationTokenSource = new();
        // CancellationToken cancellationToken = cancellationTokenSource.Token;

        public async void Start()
        {
            if (GameStarted || GameFinished) return;

            Genfood();
            GameStarted = true;
            while (true && !cancellationTokenSource.IsCancellationRequested)
            {


                await Task.Delay(Speed);

                if (cancellationTokenSource.IsCancellationRequested) break;

                switch (Cdirection)
                {
                    case Snake.w: await Gow(); break;
                    case Snake.a: await Goa(); break;
                    case Snake.s: await Gos(); break;
                    case Snake.d: await God(); break;
                }
                DataUpdater?.Invoke(this, EventArgs.Empty);

                if (GameFinished) cancellationTokenSource.Cancel();


            }

        }




        public async Task Moveto(Snake dir)
        {
            if (NumbersSet.Count > 1)
            {

                if (dir == Snake.w && Cdirection == Snake.s)
                {
                    return;
                }
                else if (dir == Snake.s && Cdirection == Snake.w)
                {
                    return;
                }
                else if (dir == Snake.a && Cdirection == Snake.d)
                {
                    return;
                }
                else if (dir == Snake.d && Cdirection == Snake.a)
                {
                    return;
                }
                else
                {
                    Cdirection = dir;
                }



            }
            else Cdirection = dir;
        }



        //Movelogic


        private async Task Gow()
        {


            if (NumbersSet.Count == 1) { }
            else if (NumbersSet[0] - 10 == NumbersSet[1])
            {
                await Gos();
                return;
            }



            if (await Gotpoint(NumbersSet, NumbersSet[0] - 10)) return;



            if (await Lost('W'))
            {
                GameFinished = true;
                return;
            };

            for (int i = NumbersSet.Count - 1; i > 0; i--)
            {
                NumbersSet[i] = NumbersSet[i - 1];

            }

            NumbersSet[0] -= 10;

        }


        private async Task Gos()
        {
            if (NumbersSet.Count == 1) { }
            else if ((NumbersSet[0] + 10) == NumbersSet[1])
            {
                await Gow();
                return;
            }

            if (await Gotpoint(NumbersSet, NumbersSet[0] + 10)) return;

            if (await Lost('S'))
            {
                GameFinished = true;
                return;
            };


            for (int i = NumbersSet.Count - 1; i > 0; i--)
            {
                NumbersSet[i] = NumbersSet[i - 1];

            }

            NumbersSet[0] += 10;
        }


        private async Task Goa()
        {


            if (NumbersSet.Count == 1) { }
            else if (NumbersSet[0] - 1 == NumbersSet[1])
            {
                await God();
                return;
            }

            if (await Gotpoint(NumbersSet, NumbersSet[0] - 1)) return;


            if (await Lost('A'))
            {
                GameFinished = true;
                return;
            };

            for (int i = NumbersSet.Count - 1; i > 0; i--)
            {
                NumbersSet[i] = NumbersSet[i - 1];

            }

            NumbersSet[0] -= 1;
        }

        private async Task God()
        {
            if (NumbersSet.Count == 1) { }
            else if (NumbersSet[0] + 1 == NumbersSet[1])
            {
                await Goa();
                return;
            }

            if (await Gotpoint(NumbersSet, NumbersSet[0] + 1)) return;



            if (await Lost('D'))
            {
                GameFinished = true;
                return;
            };

            for (int i = NumbersSet.Count - 1; i > 0; i--)
            {
                NumbersSet[i] = NumbersSet[i - 1];

            }


            NumbersSet[0] += 1;



        }




        private async Task<bool> Gotpoint(List<int> ez, int valz)
        {

            if (valz == Foodposition)
            {
                ez.Insert(0, valz);

                Genfood();
                Score += NumbersSet.Count();
                Speed -= 10;

                return true;

            }
            else return false;


        }



        private async Task<bool> Lost(char move)
        {
            
                if (await Checkdup()) { return true; }
               

                switch (move)
                {
                    case 'W':
                        {
                            if (NumbersSet[0] - 10 < 10) return true;
                            break;
                        }
                    case 'A':
                        {
                            if (((NumbersSet[0] - 1) % 10) == 9) return true;
                            break;
                        }
                    case 'S':
                        {
                            if (NumbersSet[0] + 10 > 99) return true;
                            break;
                        }

                //case 'D':
                //    {
                //        if (((NumbersSet[0] + 1) / 10).ToString()[0] == (NumbersSet[0] / 10 + 1).ToString()[0]) return true;
                //        break;
                //    }
                case 'D':
                    {
                        if (NumbersSet[0] % 10 == 9) return true;
                        break;
                    }
            }




                return false;
            






        }


        private async Task<bool> Checkdup()
        {

            HashSet<int> peprz = new(NumbersSet);

            if (peprz.Count < NumbersSet.Count)
            {
                return true;
            }
            else return false;
         
        }





    }



        public enum Snake 
    {
        w,
        a,
        s,
        d
    }


   


}
