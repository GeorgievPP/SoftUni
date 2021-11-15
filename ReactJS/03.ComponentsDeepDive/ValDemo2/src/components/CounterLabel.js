import React from 'react';

class CounterLabel extends React.Component {
    constructor(props){
        super(props)

        this.state = {
            counter: props.counter
        }
    }

    static getDerivedStateFromProps(props) {
        return {
            counter: props.counter
        }
    }
    
    render() {
        return (
            <span>Counter: {this.props.state.counter}</span>
        )
    }
}

export default CounterLabel;