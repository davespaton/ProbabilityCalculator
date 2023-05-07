import { ProbabilityButton } from './components/probability-button';
import ProbabilityInput from './components/probability-input'
import {getCombinedWith, getEither} from './services/probability-api'
import { useState } from "react";

const ProbabilityView = () => {

    const [pA, setPa] = useState(0.5);
    const [pB, setPb] = useState(0.5);

    const [result, setResult] = useState<number | null>(null);

    const either = async () => {
        const result = await getEither(pA, pB);
        setResult(result.probability);
    }

    const combinedWith = async () => {
        const result = await getCombinedWith(pA, pB);
        setResult(result.probability);
    }

    const isValid = () => pA >= 0 && pA <= 1 && pB >= 0 && pB <= 1;

    return (
        <>
            <h1 className="text-3xl font-bold">Probability Calculator</h1>
            <div className="flex flex-row gap-4 mt-4">
                <ProbabilityInput name={"A"} onChange={setPa} value={pA}  />
                <ProbabilityInput name={"B"} onChange={setPb} value={pB}  />
            </div>

            {!isValid() && <span>Input values must be between 0 and 1</span>}

            <div className="flex flex-row gap-4 mt-4">
                <ProbabilityButton isDisabled={!isValid()} onClick={either} text={"Either"} />
                <ProbabilityButton isDisabled={!isValid()} onClick={combinedWith} text={"CombinedWith"} />
            </div>

            <h2 className="text-2xl font-bold mt-4">Result</h2>
            {result !== null &&
                <p
                    className="text-1xl font-bold"
                    data-testid="result">{result}
                </p>
            }
        </>
    )

}

export default ProbabilityView;