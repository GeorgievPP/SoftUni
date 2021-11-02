import React, { Component } from "react";


class Counter extends Component {
    state = {
        value: this.props.value,
        tags: []
        //imageUrl: 'https://picsum.photos/200'
    };

   /*
    constructor() {
        super();
        this.handleIncrement = this.handleIncrement.bind(this);
    }
    */

    styles = {
        fontSize: 20,
        fontWeight: "bold"
    };

    renderTags() {
        if (this.state.tags.length === 0) return <p>There are no tags!</p>
        
        return <ul>{ this.state.tags.map(tag => <li key={tag}>{ tag }</li>) }</ul>
    }

    handleIncrement = product => {
        console.log(product);
        this.setState({ value: this.state.value + 1 })
    };


    render() {
        console.log('props', this.props);
        
        return (
            <div>
                {this.props.children}
                <h4>Second Counter #{this.props.id}</h4>

                <span style={this.styles}>{this.formatCount()}</span>
                <button onClick={ () => this.handleIncrement({ id: 1 }) }>Increment</button>
                <span style={{ fontSize: 30 }}>{this.formatCount()}</span>
                <div>
                    { this.state.tags.length === 0 && "Please create a new tag" }
                    { this.renderTags() }
                </div>
            
            </div>
        );
    }

    formatCount() {
        const{ value: count } = this.state;
        return count === 0 ? "Zero" : count;
    }
}

export default Counter;