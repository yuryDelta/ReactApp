import React, { useState } from 'react'
import RowData from './RowData'

function GridData({ currencies, onUpdateRowData }) {


    return (
        <div>
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
                        <RowData
                            rowdata={currentItem}
                        />)}
                </tbody>
            </table> 
        </div>
    )
}
export default GridData