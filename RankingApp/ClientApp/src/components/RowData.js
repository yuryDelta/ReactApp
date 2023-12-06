import React from 'react'

function RowData({ rowdata: { id, itemName, bidPrice, askPrice, isActive } }) {

    return (
        <tr key={id}>
            <td>{itemName}</td>
            <td>{bidPrice}</td>
            <td>{askPrice}</td>
        </tr>
    )
}
export default RowData