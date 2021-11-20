import { useState } from 'react';

import Modal from './Modal';
//import Backdrop from './components/Backdrop';

function Todo(props) {
    const [ modalIsOpen, setModalIsOpen ] = useState(false);

    function deleteHandler() {
        setModalIsOpen(true);
    }

  return (
    <div className="card">
      <h2>{props.text}</h2>
      <div className="action">
        <button className="btn" onClick={deleteHandler}>Delete</button>
      </div>
      { modalIsOpen ? <Modal /> : null}
    </div>
  );
}

export default Todo;
