namespace PokerAlgo{

	class Player
	{
		public string Name { get; set; }
		public Tuple<Card, Card> Hand { get; set; }
		
		public List<WinningHand> WinningHands { get; set; }
		public int HighestScore { get; set; }


		public Player(string name, Card first, Card second)
		{
			this.Name = name;
			this.Hand = new Tuple<Card, Card>(first, second);
			
			this.Hand.Item1.IsPlayerCard = true;
			this.Hand.Item2.IsPlayerCard = true;

			this.HighestScore = 0;
			this.WinningHands = new();
		}

		public override string ToString()
		{
			return $"{Name}: {Hand.Item1} {Hand.Item2}";
		}

		public void SortWinningHands(){
			WinningHands.OrderByDescending(h => h.Type);
		}
		public void SortHand(){
			Tuple<Card, Card> handTemp;
			if(Hand.Item1.Value > Hand.Item2.Value){
				handTemp = new(Hand.Item2, Hand.Item1);
				Hand = handTemp;
				// Console.WriteLine(Hand);
			}else{
				// Console.WriteLine(Hand);
			}
		}
	}
}