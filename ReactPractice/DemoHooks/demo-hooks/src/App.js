import React, { useEffect, useState } from "react";
import { Hello } from "./Hello";
import { useForm } from "./useForm";

function App() {
  const [values, handleChange] = useForm({
    email: "",
    password: "",
    firstName: "",
  });

  const [showHello, setShowHello] = useState(true);

  /* useEffect(() => {
  const onMouseMove = e => {
    console.log(e);
  };
  window.addEventListener('mousemove', onMouseMove);

    return () => {
      window.removeEventListener("mousemove", onMouseMove);
    };
  }, []);
*/
  useEffect(() => {
    console.log("mount1");
  }, []);

  useEffect(() => {
    console.log("mount2");
  }, []);

  return (
    <div>
      <>
        {/* <button onClick={() => setShowHello(!showHello)}>toggle</button> */}
        {/* {showHello && <Hello />} */}
        <input name="email" value={values.email} onChange={handleChange} />
        <input
          name="firstName"
          placeholder="first name"
          value={values.firstName}
          onChange={handleChange}
        />
        <input
          type="password"
          name="password"
          value={values.password}
          onChange={handleChange}
        />
      </>
    </div>
  );
}

export default App;
