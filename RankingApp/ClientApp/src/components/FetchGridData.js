import React, { Component } from 'react';

export class FetchGridData extends Component {
    static displayName = FetchGridData.name;

    constructor(props) {
        super(props);
        this.state = { currencies: [], loading: true };
    }

    componentDidMount() {
        this.populateCurrencyData();
    }

    static renderCurrencyTable(currencies) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Currency</th>
                        <th>Buy rate</th>
                        <th>Sell rate</th>
                    </tr>
                </thead>
                <tbody>
                    {currencies.map(currentItem =>
                        <tr key={currentItem.id}>
                            <td>{currentItem.itemName}</td>
                            <td>{currentItem.bidPrice}</td>
                            <td>{currentItem.askPrice}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchGridData.renderCurrencyTable(this.state.currencies);

        return (
            <div>
                <h1 id="tabelLabel" >Current Eur Rates</h1>
                {contents}
            </div>
        );
    }

    async populateCurrencyData() {
        const response = await fetch('items');
        const data = await response.json();
        this.setState({ currencies: data, loading: false });
    }
}
