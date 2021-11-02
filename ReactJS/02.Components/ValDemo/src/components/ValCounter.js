import React, { Component } from "react";

class ValCounter extends Component {
    constructor(props) {
        super(props);

        this.state = {
            counter: props.counter,
            example: "Example",
            data: []
        }

        this.updateCounter = this.updateCounter.bind(this);
    }

    updateCounter() {
        const { counter } = this.state;
        this.setState({
            counter: counter + 1,
        });
    }

    /*
    updateCounter = () => {
        this.setState({
            counter: this.state.counter + 1,
            example: `${this.state.example}1`
        });

        this.example = `${this.example}1`;
    }

   
   submit = () => {
        fetch().then(data => {
            this.setState({
                data: data
            });
        });
    }

    <button onClick={this.submit}>Submit</button>
    {this.state.data}
    */


    render() {
        return <div>
            {this.state.example} Counter: {this.state.counter}
            <button onClick={this.updateCounter}>Click</button>
           
        </div>
    }
}

export default ValCounter;