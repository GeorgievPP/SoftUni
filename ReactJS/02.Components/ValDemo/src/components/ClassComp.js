import { Component } from 'react';
import ValCounter from './ValCounter';
import Input from './Input';


class ClassComp extends Component {
    constructor(props) {
        super(props);

        this.state = {
            hideCounters: false,
            isLoading: true
        }

    }

    componentDidMount() {
        setTimeout(() => {
            this.setState({
                isLoading: false
            });
        }, 2000);
    }

    toggleCounters = () => {
        this.setState({
            hideCounters: !this.state.hideCounters
        });
    }

    render() {

        if (this.state.isLoading) {
            return (
                <span>Loading...</span>
            )
        }

        return <div>
            <Input />
            {this.state.hideCounters ? null : (
                <div>
                    <p>Class Component: </p>
                    <ValCounter counter={0} />
                    <ValCounter counter={0} />
                    <ValCounter counter={0} />
                    <ValCounter counter={0} />
                </div>
            )}

            <button onClick={this.toggleCounters}>Toggle Counters</button>

        </div>
    }

}

export default ClassComp;