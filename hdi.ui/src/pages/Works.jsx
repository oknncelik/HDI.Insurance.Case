import React, { useState } from 'react'
import WorkTable from '../components/works/WorkTable';

function Works() {
    const [count, setCount] = useState(0)

    return (
        <>
            <div className="container">
                <br />
                <h1>İşler</h1>
                <br />
                <WorkTable/>
            </div>
        </>
    )
}

export default Works