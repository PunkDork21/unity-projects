using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class triviagameloop : MonoBehaviour {

	public struct Question
	{
		public string questionText;
		public string[] answers;
		public int correctAnswerIndex;

		public Question(string questionText, string[] answers, int correctAnswerIndex)
		{
			
			this.questionText=questionText;
			this.answers = answers;
			this.correctAnswerIndex = correctAnswerIndex;
		}

	}

	private Question currentQuestion = new Question("What is your favorite color?", new string[]{"Blue", "Yellow", "Red", "White", "Black"}, 0);
	public Button[] answerButton;
	public Text questionText;

	private Question[] questions = new Question[10];
	private int currentQuestionIndex;
	private int[] questionNumbersChosen = new int[5];
	private int questionsFinished;

	public GameObject[] triviaPanels;
	public GameObject finalResultsPanel;
	public Text resultsText;
	private int numberOfCorrectAnswers;
	private bool allowSelection = true;
	public GameObject feedbackText;

	// Use this for initialization

	void Start () {
		for (int i = 0; i < questionNumbersChosen.Length; i++) {
			questionNumbersChosen [i] = -1;
		}

		questions[0] = new Question("What is your favorite color?", new string[]{"Blue", "Yellow", "Red", "White", "Black"}, 0);
		questions[1] = new Question("A is the father of B. But B is not the son of A. How’s that possible?", new string[]{"B's adopted", "B time traveled and is his own father", "A is a liar", "A's wife cheated on him", "B is a daughter"}, 4);
		questions[2] = new Question("An electric train is moving north at 100mph and a wind is blowing to the west at 10mph. Which way does the smoke blow? ", new string[]{"East", "North", "It's an electric train", "South", "West"}, 2);
		questions[3] = new Question("What ended in the year 1919?", new string[]{"Theodore Rosevelt's presidency as he passed away at 60", "1918", "The legality of alcohol as prohibition began", "Babe Ruth's time under the red sox as he is transfered to the NY Yankees", "The Seattle General Strike"}, 1);
		questions[4] = new Question("If it took eight men ten hours to build a wall,how long would it take four men to build it?", new string[]{"10", "5", "20", "4", "None, it's already built"}, 4);
		questions[5] = new Question("If there are 6 apples and you take away 4, how many do you have?", new string[]{"4", "6", "2", "1", "5"}, 0);
		questions[6] = new Question("If you had only one match, and entered a dark room containing an oil lamp, some newspaper, gasoline, and some kindling wood, which would you light first?", new string[]{"oil lamp", "the match", "kindling wood", "newspaper", "gasoline"}, 1);
		questions[7] = new Question("Some months have 31 days, others have 30 days. How many have 28 days?", new string[]{"1", "2", "9", "0", "All of them"}, 4);
		questions[8] = new Question("Select the second number", new string[]{"0", "1", "2", "3", "4"}, 1);
		questions[9] = new Question("Do you remember your favorite color?", new string[]{"Blue", "Yellow", "Red", "White", "Black"}, 0);

		chooseQuestions ();
		assignQuestion (questionNumbersChosen[0]);

	}

	// Update is called once per frame
	void Update () {
		quitGame ();
	}

	void assignQuestion(int questionNum){

		currentQuestion = questions [questionNum];

		questionText.text = currentQuestion.questionText;
		for (int i = 0; i < answerButton.Length; i++) {

			answerButton[i].GetComponentInChildren<Text> ().text = currentQuestion.answers [i];

		}

	}

	public void checkAnswer(int buttonNum){
		if (allowSelection) {
			if (buttonNum == currentQuestion.correctAnswerIndex) {
				print ("correct");
				numberOfCorrectAnswers++;
				feedbackText.GetComponent<Text>().text = "Correct";
				feedbackText.GetComponent<Text> ().color = Color.green;
			} else {
				print ("incorrect");
				feedbackText.GetComponent<Text>().text = "Incorrect, dumbass";
				feedbackText.GetComponent<Text> ().color = Color.red;
			}
			StartCoroutine ("continueAfterFeedback");
		}
	}


	void chooseQuestions(){

		for (int i = 0; i < questionNumbersChosen.Length; i++) {

			int questionNum = Random.Range (0, questions.Length);
			if(numberNotContained(questionNumbersChosen,questionNum)) {
				questionNumbersChosen[i] = questionNum;
			
			} else {
				i--;
			}
		}
		
		currentQuestionIndex = Random.Range (0, questions.Length);
	}

	bool numberNotContained(int[] numbers, int num){
		for(int i = 0; i < numbers.Length; i++){
			if (num == numbers[i]){
				return false;
			}
		}		return true;
	}

	public void moveToNextQuestion(){
		assignQuestion (questionNumbersChosen [questionNumbersChosen.Length - 1 - questionsFinished]);
	}

	void displayResults(){
		switch (numberOfCorrectAnswers) {

		case 5:
			resultsText.text = "5 out of 5 correct. You are all knowing";
			break;

		case 4:
			resultsText.text = "4 out of 5 correct. You are smart but not as smart as 5 out of 5";
			break;

		case 3:
			resultsText.text = "3 out of 5 correct. You are decently average";
			break;

		case 2:
			resultsText.text = "2 out of 5 correct. Don't quit your day job";
			break;

		case 1:
			resultsText.text = "1 out of 5 correct. You are well below average. Don't try again, you are disgracing the human race";
			break;

		case 0:
			resultsText.text = "0 out of 5 correct. Woah there buddy, you need some serious help. GED much?";
			break;
		default:
			print ("incorrect intellegence level.");
			break;
		}
	}
	public void restartLevel(){
		Application.LoadLevel (Application.loadedLevelName);
	}

	IEnumerator continueAfterFeedback(){
		allowSelection = false;
		feedbackText.SetActive (true);
		yield return new WaitForSeconds (1.0f);
		if (questionsFinished < questionNumbersChosen.Length - 1) {
			moveToNextQuestion ();
			questionsFinished++;
		} else {
			foreach (GameObject p in triviaPanels) {
				p.SetActive (false);
			}
			finalResultsPanel.SetActive (true);
			displayResults();
		}
		allowSelection = true;
		feedbackText.SetActive (false);
	}
	//CHecks for escape input to quit game
	void quitGame(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
}
