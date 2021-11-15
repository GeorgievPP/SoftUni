import { Component } from 'react';

class Counter extends Component {
    constructor(props) {
        super(props);

        this.state = {
            count: 11,
            collectionName: 'My Books'
        };
    }

    render() {

        //console.log('re-render');
        return (
            <div className="counter">
                <h3>{this.state.collectionName}Counter</h3>
                <button onClick={(e) => this.setState({count: this.state.count - 1})}>-</button>
                <span>{this.state.count}</span>
                <button onClick={(e) => this.setState({count: this.state.count + 1})}>+</button>
            </div>
        );
    }
}

export default Counter;