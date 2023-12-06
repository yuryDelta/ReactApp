import React, { useEffect, useState } from "react";
import GridData from "./GridData";

function FetchGridData() {
    // set state
    const [currencies, setCurrencies] = useState([]);

    // first data grab
    useEffect(() => {
        console.log('in useEffect');
        fetch('items')
            .then((resp) => resp.json())
            .then((data) => {
                setCurrencies(data)
            });
        console.log('after useEffect');
    }, []);

    // update currencies on page after edit
    function onUpdateRowData(updatedCustomer) {
        const updatedCurrencies = currencies.map(
            currency => {
                if (currency.id === updatedCustomer.id) {
                    return updatedCustomer
                } else { return currency }
            }
        )
        setCurrencies(updatedCurrencies)
    }

    return (
        <div>
            <GridData
                currencies={currencies}
                onUpdateRowData={onUpdateRowData}
            />
        </div>
    );
}
export default FetchGridData;