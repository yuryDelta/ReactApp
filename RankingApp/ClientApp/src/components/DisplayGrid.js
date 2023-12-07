import { AgGridReact } from 'ag-grid-react';
import 'ag-grid-community/dist/styles/ag-grid.css';
import 'ag-grid-community/dist/styles/ag-theme-alpine.css';

import { useState, useEffect, useMemo, useCallback } from 'react';

function DisplayGrid() {

    const [rowData, setRowData] = useState();

     const columnDefs= [
        { headerName: 'Instrument name', field: 'itemName',  editable: false },
        { headerName: 'Bid price', field: 'bidPrice',  editable: false },
        { headerName: 'Ask price', field: 'askPrice',  editable: false }
    ];

    const defaultColDef = useMemo(() => (
        {
            sortable: true,
            filter: true
        }
    ));

    const cellClickedListener = useCallback(event => {
        console.log('cellClicked', event);
    }, []);

    const fetchData = useCallback(async()=> {
        const response = await fetch('items');
        const data = await response.json();
        setRowData(data)
      }, [])

    useEffect(() => {
        setTimeout(() => {
            fetchData();
            console.log('Time out tick');
        }, 3000);
    }, [rowData]);

    const getRowId = useCallback( params => {
        return params.data.id;
      });


    console.log('Render start');
    return (
        <div>
            <div className="ag-theme-alpine" style={{ width: 500, height: 500 }}>
                <AgGridReact
                    enableCellChangeFlash={true}
                    getRowId={getRowId}
                    rowData={rowData} columnDefs={columnDefs}
                    animateRows={true} rowSelection='multiple'
                    onCellClicked={cellClickedListener}
                    defaultColDef={defaultColDef} />
            </div>
        </div>
    );
}

export default DisplayGrid;