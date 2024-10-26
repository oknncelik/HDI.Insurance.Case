import react from 'react';

function HDIModal({ open, children, onClose, title }) {
    if (!open)
        return null;

    return (
        <>
            <div className="overlay">
                <div className="hdi-modal">
                    <div className="modal-title">
                        <h4 className="m15">{ title }</h4> 
                    </div>

                    <div className="mt60">
                        {children}
                    </div>
                </div>
            </div>
        </>
    )
}

export default HDIModal