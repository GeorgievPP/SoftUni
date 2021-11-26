import React, { useState, useEffect } from "react";

import { Questionaire } from "./components";

const API_URL =
  "https://opentdb.com/api.php?amount=10&category=20&difficulty=easy&type=multiple";

function App() {
  const [questions, setQuestions] = useState([]);
  const [currentIndex, setCurrentIndex] = useState(0);
  const [score, setScore] = useState(0);
  const [showAnswers, setShowAnswers] = useState(false);

  const getResults = async () => {
    const response = await fetch(API_URL);
    const resultEntries = await response.json();
    console.log(resultEntries);
    console.log(resultEntries.results);
    setQuestions(resultEntries.results);
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
        setQuestions(data.results);
        setCurrentQuestion(data.results[0]);
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
