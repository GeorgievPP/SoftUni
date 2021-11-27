import React, { useState, useEffect } from "react";

import { Questionaire } from "./components";

const API_URL_MYTH =
  "https://opentdb.com/api.php?amount=10&category=20&difficulty=easy&type=multiple";

const API_URL_COMP = 'https://opentdb.com/api.php?amount=10&category=18&difficulty=easy&type=multiple';
function App() {
  const [questions, setQuestions] = useState([]);
  const [currentIndex, setCurrentIndex] = useState(0);
  const [score, setScore] = useState(0);
  const [showAnswers, setShowAnswers] = useState(false);

  const getResults = async () => {
    const response = await fetch(API_URL_COMP);
    const resultEntries = await response.json();
    console.log(resultEntries);
    console.log(resultEntries.results);
    //setQuestions(resultEntries.results);

    const questions = resultEntries.results.map((question) => ({
      ...question,
      answers: [question.correct_answer, ...question.incorrect_answers].sort(
        () => Math.random() - 0.5
      ),
    }));

    setQuestions(questions);
  };

  useEffect(() => {
    getResults();
  }, []);

  /*
  useEffect(() => {
    fetch(API_URL)
      .then((res) => res.json())
      .then((data) => {
        //console.log(data);
        //setQuestions(data.results);
        //setCurrentQuestion(data.results[0]);

        const questions = resultEntries.results.map((question) => ({
      ...questions,
      answers: [
        correct_answer,
        ...incorrect_answers
      ].sort(() => Math.random())
    }))
    
    setQuestions(questions);

      });
  }, []);
  */

  const handleAnswer = (answer) => {
    //const newIndex = currentIndex + 1;
    //  setCurrentIndex(newIndex);

    if (!showAnswers) {
      if (answer === questions[currentIndex].correct_answer) {
        setScore(score + 1);
      }
    }

    setShowAnswers(true);
  };

  const handleNextQuestion = () => {
    setShowAnswers(false);

    setCurrentIndex(currentIndex + 1);
  };

  return questions.length > 0 ? (
    <div className="container">
      {currentIndex >= questions.length ? (
        <h1 className="text=3xl text-white font-bold">
          Game Ended! Your score is: {score}.
        </h1>
      ) : (
        <Questionaire
          data={questions[currentIndex]}
          showAnswers={showAnswers}
          handleNextQuestion={handleNextQuestion}
          handleAnswer={handleAnswer}
        />
      )}
    </div>
  ) : (
    <h3 className="text-2xl text-white font-bold">Loading...</h3>
  );
}

export default App;
