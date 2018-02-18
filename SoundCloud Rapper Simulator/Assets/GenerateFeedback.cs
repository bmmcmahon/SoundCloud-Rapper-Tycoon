using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFeedback : MonoBehaviour {

	private SongQualities sq;

	private List<string> trashReviews;
	private List<string> disappointedReviews;
	private List<string> prettyGoodReviews;
	private List<string> hitReviews;
	private List<string> masterpieceReviews;

	// Use this for initialization
	void Start () {
		sq = GetComponent<SongQualities> ();

		trashReviews = new List<string> () {
			"My grandma can rap better than this",
			"I think he sneezed into the mic at 1:24",
			"I'd rather get a colonoscopy than listen to this again",
			"You're doing great sweetie! Love, Grandma",
			"I am literally filing a lawsuit against you",
			"Your dog barking in the background of this track was better than your second verse",
			"I can't believe the President outlawed this song",
			"My wife left me after I left this song on repeat",
			"This is objectively the worst " + sq.style + " song I've ever heard",
			"Was that supposed to be " + sq.topic + "? Yikes.",
			sq.featuring + "'s verse was a dumpster fire",
			"You singlehandedly ruined " + sq.tempo + " " + sq.style + " for me."
		};

		disappointedReviews = new List<string> () {
			"This would have been better if it sucked less",
			"You still live with your mom, don't you?",
			"meh",
			"I forgot to plug in my headphones and played this out loud and now everyone hates me",
			"Aren't you a little old to be rapping about family circus?",
			"This might have placed top 5 at a high school talent show",
			"FSKNDSFKJKS",
			"My dad won't stop playing this in the car. I hate you.",
			"Your voice sounds like when you hear pained wheezing from the adjacent bathroom stall",
			"You just inspired me to join a cult",
			"My mom is really in to " + sq.style + " lately",
			"I never want to hear another " + sq.topic + " song again.",
			sq.featuring + "'s career is over bruh",
			"What even is " + sq.tempo + " " + sq.style + "?"
		};

		prettyGoodReviews = new List<string> () {
			"#FreeChanningTatum",
			"Not bad kid",
			"This would be perfect elevator music",
			"I wish you referenced your stamp collection a bit less, but not bad!",
			"Savage Big Bird reference in the first verse.",
			"My dog loves this song",
			"I can relate to the line about your fear of beavers, good stuff",
			"I find that line about people in wheelchairs offensive",
			"Eat less carbs",
			sq.style + " reminds me of my childhood",
			sq.featuring + " was zooted for that whole verse",
			sq.tempo + " " + sq.style + " has a nice ring to it"
		};

		hitReviews = new List<string> () {
			"Bold move sampling the Price is Right theme song. I like it.",
			"I believe this is what the kids call 'dope'",
			"This is a banger",
			"This. Is. Some. Good. Shit. Right. Here.",
			"Ayy lmao",
			"This song made me violently scream-vomit",
			"You just inspired me to recycle",
			"Whoevr disliked this song knows nothig abourt good music.",
			sq.style + " makes me feel alive again",
			"I love a good " + sq.topic + " song more than my wife and kids.",
			sq.featuring + " was in your shadow on that track homie",
			"You've got " + sq.tempo + " " + sq.style + " down to a science"
		};

		masterpieceReviews = new List<string> () {
			"This song convinced me to propose to my girl",
			"Thumbs up if you're listening in 2018",
			"My life is complete",
			"Saw this featured on Pitchfork",
			"I can now grow a full head of hair! Thanks!",
			"This song makes me wanna write a 'this song makes me wanna' comment",
			"This song makes me wanna break into prison",
			"Listening to this song just improved my vocabulary",
			"I wrote my master's thesis on this song and now I'm rich",
			sq.featuring + " puts the meow in homeowner",
			"This sort of " + sq.tempo + " " + sq.style + " reminds me of how I found the Lord."
		};
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public List<string> Generate () {

		List<string> feedback = new List<string>();
	
		for (int i = 0; i < 3; i++) {
			string tempFeedback;
			do {
				tempFeedback = "\"" + GetReview () + "\"\n";
			} while(feedback.Contains(tempFeedback));
			feedback[i] = tempFeedback;
		}
		return feedback;
	}

	public string GetReview () {

		System.Random r = new System.Random ();

		// trash
		if (sq.score < 3) {
			return trashReviews [r.Next (trashReviews.Count)];
		}

		// dissapointing
		if (sq.score < 5) {
			return disappointedReviews [r.Next (disappointedReviews.Count)];
		}

		// pretty good
		if (sq.score < 8) {
			return prettyGoodReviews [r.Next (prettyGoodReviews.Count)];
		}

		// hit
		if (sq.score < 10) {
			return hitReviews [r.Next (hitReviews.Count)];
		}

		// masterpiece
		else {
			return masterpieceReviews [r.Next (masterpieceReviews.Count)];
		}
	}
}
